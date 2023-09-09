using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DSharpPlus.BetterHosting.Services.Implementation;
using DSharpPlus.BetterHosting.Services.Hosted;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DSharpPlus.BetterHosting.Hosting;

/// <summary>
/// A program initialization utility.
/// </summary>
internal sealed class BetterHostBuilder : IHostBuilder
{
    private readonly IHostBuilder builder;

    [RequiresDynamicCode(BetterHost.RequiresDynamicCodeMessage)]
    public BetterHostBuilder()
    {
        builder = new HostBuilder();
    }
    internal BetterHostBuilder(IHostBuilder builder)
    {
        Debug.Assert(builder != null);
        this.builder = builder;
    }

    /// <summary>
    /// A central location for sharing state between components during the host building process.
    /// </summary>
    public IDictionary<object, object> Properties => builder.Properties;

    public bool IncludeDefaults { get; set; } = true;

    /// <summary>
    /// Set up the configuration for the builder itself. This will be used to initialize the <see cref="IHostEnvironment"/>
    /// for use later in the build process. This can be called multiple times and the results will be additive.
    /// </summary>
    /// <param name="configureDelegate">The delegate for configuring the <see cref="IConfigurationBuilder"/> that will be used
    /// to construct the <see cref="IConfiguration"/> for the host.</param>
    /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
    public IHostBuilder ConfigureHostConfiguration(Action<IConfigurationBuilder> configureDelegate)
    {
        builder.ConfigureHostConfiguration(configureDelegate);
        return this;
    }

    /// <summary>
    /// Sets up the configuration for the remainder of the build process and application. This can be called multiple times and
    /// the results will be additive. The results will be available at <see cref="HostBuilderContext.Configuration"/> for
    /// subsequent operations, as well as in <see cref="IHost.Services"/>.
    /// </summary>
    /// <param name="configureDelegate">The delegate for configuring the <see cref="IConfigurationBuilder"/> that will be used
    /// to construct the <see cref="IConfiguration"/> for the host.</param>
    /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
    public IHostBuilder ConfigureAppConfiguration(Action<HostBuilderContext, IConfigurationBuilder> configureDelegate)
    {
        builder.ConfigureAppConfiguration(configureDelegate);
        return this;
    }

    /// <summary>
    /// Adds services to the container. This can be called multiple times and the results will be additive.
    /// </summary>
    /// <param name="configureDelegate">The delegate for configuring the <see cref="IConfigurationBuilder"/> that will be used
    /// to construct the <see cref="IConfiguration"/> for the host.</param>
    /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
    public IHostBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
    {
        builder.ConfigureServices(configureDelegate);
        return this;
    }

    /// <summary>
    /// Overrides the factory used to create the service provider.
    /// </summary>
    /// <typeparam name="TContainerBuilder">The type of the builder to create.</typeparam>
    /// <param name="factory">A factory used for creating service providers.</param>
    /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
    public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory) where TContainerBuilder : notnull
    {
        builder.UseServiceProviderFactory(factory);
        return this;
    }

    /// <summary>
    /// Overrides the factory used to create the service provider.
    /// </summary>
    /// <param name="factory">A factory used for creating service providers.</param>
    /// <typeparam name="TContainerBuilder">The type of the builder to create.</typeparam>
    /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
    public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factory) where TContainerBuilder : notnull
    {
        builder.UseServiceProviderFactory(factory);
        return this;
    }

    /// <summary>
    /// Enables configuring the instantiated dependency container. This can be called multiple times and
    /// the results will be additive.
    /// </summary>
    /// <typeparam name="TContainerBuilder">The type of the builder to create.</typeparam>
    /// <param name="configureDelegate">The delegate for configuring the <see cref="IConfigurationBuilder"/> that will be used
    /// to construct the <see cref="IConfiguration"/> for the host.</param>
    /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
    public IHostBuilder ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext, TContainerBuilder> configureDelegate)
    {
        builder.ConfigureContainer(configureDelegate);
        return this;
    }

    /// <summary>
    /// Run the given actions to initialize the host. This can only be called once.
    /// </summary>
    /// <returns>An initialized <see cref="IHost"/></returns>
    /// <remarks>Adds basic services to the host such as application lifetime, host environment, and logging.</remarks>
    public IHost Build()
    {
        AddCore();
        if (IncludeDefaults)
            AddDefaults();
        IHost host = builder.Build();
        return new HostStartupWrapper(host);
    }
    private void AddCore() => ConfigureServices((context, services) =>
    {
        services.TryAddSingleton<DiscordClient>((sp) =>
        {
            DiscordConfiguration config = sp.GetRequiredService<IDiscordConfigurationProvider>().GetConfiguration();
            DiscordClient client = new(config);

            List<Task> asyncConfiguration = new();
            foreach (IDiscordClientConfigurator configurator in sp.GetServices<IDiscordClientConfigurator>())
            {
                ValueTask VT = configurator.Configure(client);
                if (!VT.IsCompletedSuccessfully)
                    asyncConfiguration.Add(VT.AsTask());
            }
            Task.WaitAll(asyncConfiguration.ToArray());
            return client;
        });

        services.AddHostedService<DiscordClientHost>();
    });

    private void AddDefaults()
    {
        ConfigureServices((context, services) =>
        {
            services.TryAddSingleton<IDiscordConfigurationProvider, FallbackDiscordConfigurationProvider>();
        });
    }
}