using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace FreddyBot.Core.Services.Implementation.Configuration;

public class ConfigureCommandsNext : IDiscordClientConfigurator
{
    private readonly IServiceProvider provider;
    public ConfigureCommandsNext(IServiceProvider provider) => this.provider = provider;

    public void Configure(DiscordClient client)
    {
        CommandsNextExtension config = client.UseCommandsNext(new()
        {
            Services = provider,
            StringPrefixes = new[] { "!", "/" }
        });

        config.RegisterCommands(typeof(Program).Assembly);
    }

    public async Task ConfigureSharded(DiscordShardedClient shard)
    {
        IReadOnlyDictionary<int, CommandsNextExtension> configs = await shard.UseCommandsNextAsync(new()
        {
            Services = provider,
            StringPrefixes = new[] { "!", "/" }
        });

        foreach (CommandsNextExtension config in configs.Values)
            config.RegisterCommands(typeof(Program).Assembly);
    }
}
