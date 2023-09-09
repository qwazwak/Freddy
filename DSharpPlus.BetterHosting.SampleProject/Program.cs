using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DSharpPlus.EventsBinderExtension;
using DSharpPlus.BetterHosting.Services.Implementation.Configuration;
using DSharpPlus.BetterHosting.Hosting;
using DSharpPlus.BetterHosting.CommandsNext.Services;

IHostBuilder builder = BetterHost.CreateDefaultBuilder(args);

builder.ConfigureServices((services) =>
{
    services.AddTransient<ICommandsNextConfigurationProvider, CommmandsNextConfigurationProviderService>();
    services.AddTransient<ICommandsNextConfigurator, CommmandsNextRegisterService>();
    //services.AddTransient<IDiscordClientConfigurator, ConfigureDiscordClientEvents>();
    services.AddEventsNextHandlers(typeof(Program).Assembly);
});

IHost host = builder.Build();

await host.RunAsync();
