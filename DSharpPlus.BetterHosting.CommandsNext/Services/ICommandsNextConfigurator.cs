using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.CommandsNext.Services;

public interface ICommandsNextConfigurator
{
    public ValueTask Configure(CommandsNextExtension extension);
    public ValueTask ConfigureSharded(int shardID, CommandsNextExtension extension) => Configure(extension);
}
/*
public abstract class CommandsNextConfigurator : IDiscordClientConfigurator
{
    private readonly IServiceProvider provider;

    public CommandsNextConfigurator(IServiceProvider provider) => this.provider = provider;

    protected virtual CommandsNextConfiguration GetCommandsNextConfiguration() => new()
    {
        Services = provider
    };

    protected virtual CommandsNextExtension AddCommmandsNext(DiscordClient client) => client.UseCommandsNext(GetCommandsNextConfiguration());

    protected virtual IEnumerable<Assembly> GetAssembliesWithCommands()
    {
        Assembly? entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly != null)
            yield return entryAssembly;
    }
    private static IEnumerable<Type> GetCommandTypes(Assembly assembly)
        => GetCommandTypes(assembly.GetType)
    private static IEnumerable<Type> GetCommandTypes(IEnumerable<Type> types)
    {

    }
    protected virtual IEnumerable<Type> GetCommandTypes()
    {
        foreach (Assembly assembly in GetAssembliesWithCommands())
        {
            foreach (var item in assembly.GetExportedTypes)
            {

            }
            if (!CommandsNextReflector.Utilities.IsModuleCandidateType())

        }
        Assembly? entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly != null)
            yield return entryAssembly;
    }

    public ValueTask Configure(DiscordClient client)
    {
        CommandsNextExtension config = AddCommmandsNext(client);
        config.RegisterCommands(typeof(Program).Assembly);

        return ValueTask.CompletedTask;
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
*/