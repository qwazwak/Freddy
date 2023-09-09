//TODO:
#if false
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharp.BetterHosting;
using DSharp.BetterHosting.Services;
using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace DSharp.BetterHosting.Services.Implementation.Configuration;

public class ConfigureSlashCommands : IDiscordClientConfigurator
{
    private readonly IServiceProvider provider;
    public ConfigureSlashCommands(IServiceProvider provider) => this.provider = provider;

    public void Configure(DiscordClient client)
    {
        SlashCommandsExtension config = client.UseSlashCommands(new() { Services = provider, });

        config.RegisterCommands(typeof(Program).Assembly);
    }

    public async Task ConfigureSharded(DiscordShardedClient shard)
    {
        IReadOnlyDictionary<int, SlashCommandsExtension> configs = await shard.UseSlashCommandsAsync(new() { Services = provider, });

        foreach (SlashCommandsExtension config in configs.Values)
            config.RegisterCommands(typeof(Program).Assembly);
    }
}
#endif