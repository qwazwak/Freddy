using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.Services.Implementation.Configuration;

public sealed class CommandsNextSetup : IDiscordClientConfigurator
{
    private readonly ICommandsNextConfigurationProvider configurationProvider;
    private readonly IEnumerable<ICommandsNextConfigurator> configurators;

    public CommandsNextSetup(ICommandsNextConfigurationProvider configurationProvider, IEnumerable<ICommandsNextConfigurator> configurators)
    {
        this.configurationProvider = configurationProvider;
        this.configurators = configurators;
    }

    public async ValueTask Configure(DiscordClient client)
    {
        CommandsNextConfiguration options = await configurationProvider.GetConfiguration();

        CommandsNextExtension commandsNext = client.UseCommandsNext(options);

        foreach (ICommandsNextConfigurator configurator in configurators)
            await configurator.Configure(commandsNext);
    }

    public async Task ConfigureSharded(DiscordShardedClient shard)
    {
        CommandsNextConfiguration options = await configurationProvider.GetConfiguration();

        IReadOnlyDictionary<int, CommandsNextExtension> configs = await shard.UseCommandsNextAsync(options);

        foreach (KeyValuePair<int, CommandsNextExtension> kvp in configs)
        {
            foreach (ICommandsNextConfigurator configurator in configurators)
                await configurator.ConfigureSharded(kvp.Key, kvp.Value);
        }
    }
}