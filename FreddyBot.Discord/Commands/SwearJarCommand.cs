using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.Extensions.Logging;
using FreddyBot.Core.Services;

namespace FreddyBot.Discord.Commands;

public sealed class SwearJarCommand : BaseCommandModule
{
    private readonly ILogger<SwearJarCommand> logger;
    private readonly ISwearJar swearJar;

    public SwearJarCommand(ILogger<SwearJarCommand> logger, ISwearJar swearJar)
    {
        this.logger = logger;
        this.swearJar = swearJar;
    }

    [Command("sj"), Description("Check the swear jar balance"), Aliases("swearJarBal")]
    public async Task CheckSwearJar(CommandContext ctx)
    {
        decimal JarValue = await swearJar.GetCurrentValue();
        logger.LogDebug("Found {JarValue} in the swear jar.", JarValue.ToString("C2"));
        await ctx.Message.RespondAsync($"There is {JarValue:C2} in the swear jar.");
    }
}