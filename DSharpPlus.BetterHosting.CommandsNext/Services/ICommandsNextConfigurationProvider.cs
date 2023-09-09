using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.CommandsNext.Services;

public interface ICommandsNextConfigurationProvider
{
    public ValueTask<CommandsNextConfiguration> GetConfiguration();
}
