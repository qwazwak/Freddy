#if false
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using DSharp.BetterHosting.CommandsNext.Services;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;

namespace DSharp.BetterHosting.Services.Implementation.Configuration;

public abstract class CommandsNextRegistrationConfigurator : ICommandsNextConfigurator
{
    private readonly ILogger<CommandsNextRegistrationConfigurator> logger;

    public CommandsNextRegistrationConfigurator(ILogger<CommandsNextRegistrationConfigurator> logger) => this.logger = logger;

    protected virtual IEnumerable<Assembly> GetAssembliesWithCommands()
    {
        Assembly? entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly != null)
            yield return entryAssembly;
    }
    private static IEnumerable<Type> GetCommandTypes(Assembly assembly)
        => GetCommandTypes(assembly);
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

    public ValueTask Configure(CommandsNextExtension extension)
    {
        extension.
    }
}
#endif