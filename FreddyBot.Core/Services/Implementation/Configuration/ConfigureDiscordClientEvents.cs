using System;
using DSharpPlus;
using DSharpPlus.EventsBinderExtension;

namespace FreddyBot.Core.Services.Implementation.Configuration;

public class ConfigureDiscordClientEvents : IDiscordClientConfigurator
{
    private readonly IServiceProvider provider;
    public ConfigureDiscordClientEvents(IServiceProvider provider) => this.provider = provider;

    public void Configure(DiscordClient client)
    {
        EventsNextExtension eventsNext = client.UseEventsNext(new()
        {
            Services = provider,
        });

        // Register commands
        // CommandsNext will search the assembly for any classes that inherit from BaseCommandModule and register them as commands.
        eventsNext.BindEventHandlers(typeof(Program).Assembly);
        /*EventBinder.BindMessageCreated<AtFreddyHandler>(client, provider);
        EventBinder.BindMessageCreated<CreepyHandler>(client, provider);
        EventBinder.BindMessageCreated<PHPHandler>(client, provider);
        EventBinder.BindMessageCreated<SwearJarHandler>(client, provider);*/
    }
}
