using System;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.Services.Implementation.Configuration;

public class CommmandsNextConfigurationProviderService : ICommandsNextConfigurationProvider
{
    private readonly IServiceProvider provider;
    public CommmandsNextConfigurationProviderService(IServiceProvider provider) => this.provider = provider;

    public ValueTask<CommandsNextConfiguration> GetConfiguration() => ValueTask.FromResult(new CommandsNextConfiguration()
    {
        Services = provider,
        StringPrefixes = new[] { "!", "/" }
    });
}
