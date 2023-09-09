using System.Threading.Tasks;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.CommandsNext;

namespace DSharpPlus.BetterHosting.Services.Implementation.Configuration;

public class CommmandsNextRegisterService : ICommandsNextConfigurator
{
    public ValueTask Configure(CommandsNextExtension extension)
    {
        extension.RegisterCommands(GetType().Assembly);
        return ValueTask.CompletedTask;
    }
}
