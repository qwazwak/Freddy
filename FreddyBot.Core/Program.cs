using System;
using System.Threading.Tasks;
using DSharpPlus;
using FreddyBot.Core.Services.Options;
using FreddyBot.Core.Services;
using FreddyBot.Core.Services.Implementation;
using FreddyBot.Core.Services.Implementation.Configuration;
using FreddyBot.Core.Services.Hosted;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using DSharpPlus.EventsBinderExtension;
using FreddyBot.Core.Services.Implementation.Database;
using FreddyBot.Core.Services.Extensions;

namespace FreddyBot.Core;

public class Program
{
    public static async Task Main(string[]? args)
    {
        IHost host = Build(args);

        await host.RunAsync();
    }

    public static IHost Build(string[]? args) => GetBuilder(args).Build();

    public static HostApplicationBuilder GetBuilder(string[]? args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        ConfigureServices(builder.Services);

        return builder;
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();

        services.AddOptions();
        services.AddHttpClient();

        services.AddOptions<DiscordClientOptions>();

        services.AddTransient<SystemSetupRunner>();

        services.AddTransient<ISystemSetup, DBFileSetup>();

        services.AddTransient<IDiscordClientConfigurator, ConfigureCommandsNext>();
        services.AddTransient<IDiscordClientConfigurator, ConfigureDiscordClientEvents>();
        services.AddTransient<DiscordConfiguration>((sp) =>
        {
            DiscordClientOptions options = sp.GetRequiredService<IOptions<DiscordClientOptions>>().Value;

            return new()
            {
                Token = options.DiscordToken,

                // We're asking for unprivileged intents, which means we won't receive any member or presence updates.
                // Privileged intents must be enabled in the Discord Developer Portal.
                TokenType = TokenType.Bot,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,

                // TODO: Enable the message content intent in the Discord Developer Portal.
                // The !ping command will not work without it.
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            };
        });
        services.AddSingleton<DiscordClient>((sp) =>
        {
            DiscordConfiguration config = sp.GetRequiredService<DiscordConfiguration>();
            DiscordClient client = new(config);

            foreach (IDiscordClientConfigurator configurator in sp.GetServices<IDiscordClientConfigurator>())
                configurator.Configure(client);

            return client;
        });

        services.AddSingleton(Random.Shared); // We're using the shared instance of Random for simplicity.

        AddDbContext<SwearJarContext>(services, connectionStringName: null);
        services.AddEventsNextHandlers(typeof(Program).Assembly);

        static void AddDbContext<TContext>(IServiceCollection services, string? connectionStringName) where TContext : Microsoft.EntityFrameworkCore.DbContext
        {
            services.AddDbContext<TContext>((global::System.IServiceProvider provider, global::Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optBuilder) =>
            {
                global::FreddyBot.Core.Services.IConnectionStringsProvider connStringProvider = provider.GetRequiredService<global::FreddyBot.Core.Services.IConnectionStringsProvider>();
                optBuilder.UseSqlite((string)connStringProvider.GetRequired(connectionStringName));
            });
        }

        services.AddTransient<ISwearJar, DbSwearJar>();

        services.AddScoped<IProfanityDetector, SimpleSwearDetector>();

        services.AddScoped<ISentimentAnalyzer, ApiNinja>();
        services.AddScoped<IPasswordGenerator, ApiNinja>();

        services.AddHostedService<DiscordClientHost>();
    }
}
