using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.Extensions.Logging;
using FreddyBot.Core.Services;
using DSharpPlus.SlashCommands;
using System.Reflection.Emit;
using DSharpPlus.Entities;
using DSharpPlus;

namespace FreddyBot.Core.Commands;

public sealed class SwearJarCommand : ApplicationCommandModule
{
    private readonly ILogger<SwearJarCommand> logger;
    private readonly ISwearJar swearJar;

    public SwearJarCommand(ILogger<SwearJarCommand> logger, ISwearJar swearJar)
    {
        this.logger = logger;
        this.swearJar = swearJar;
    }

    [SlashCommand("sj", "Check the swear jar balance")]
    public async Task CheckSwearJar(InteractionContext ctx)
    {
        decimal JarValue = await swearJar.GetCurrentValue(ctx.Guild.Id);
        logger.LogDebug("Found {JarValue} in the swear jar for guild {guild}", JarValue.ToString("C2"), ctx.Guild.Id);
        await ctx.CreateResponseAsync($"There is {JarValue:C2} in the swear jar.");
    }
}