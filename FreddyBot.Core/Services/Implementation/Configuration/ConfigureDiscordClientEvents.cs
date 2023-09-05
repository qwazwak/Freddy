using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventsBinderExtension;
using DSharpPlus.SlashCommands;

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

        eventsNext.BindEventHandlers(typeof(Program).Assembly);
    }

    public async Task ConfigureSharded(DiscordShardedClient shard)
    {
        IReadOnlyDictionary<int, EventsNextExtension> configs = await shard.UseEventsNextAsync(new() { Services = provider, });

        foreach (EventsNextExtension config in configs.Values)
            config.BindEventHandlers(typeof(Program).Assembly);
    }
}
