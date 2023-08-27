using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.Extensions.Logging;

namespace FreddyBot.Discord.Commands;

// Inherit from BaseCommandModule so that CommandsNext can recognize this class as a command.
public sealed class PingCommand : BaseCommandModule
{
    private readonly ILogger<PingCommand> logger;

    public PingCommand(ILogger<PingCommand> logger)
    {
        this.logger = logger;
    }

    // Register the method as a command, specifying the name and description.
    // Unfortunately, CommandsNext does not support static methods.
    [Command("ping"), Description("Pings the bot and returns the gateway latency."), Aliases("pong")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "required for commandsnext")]
    public Task PingAsync(CommandContext ctx) =>
        // The CommandContext provides access to the DiscordClient, the message, the channel, etc.
        // If the CommandContext is not provided as a parameter, CommandsNext will ignore the method.
        // Additionally, without the CommandContext, it would be impossible to respond to the user.
        ctx.RespondAsync($"Pong! The gateway latency is {ctx.Client.Ping}ms.");

    //
    // Summary:
    //     Called after a command in the implementing module is successfully executed.
    //
    // Parameters:
    //   ctx:
    //     Context in which the method is being executed.
    public override Task AfterExecutionAsync(CommandContext ctx)
    {
        logger.LogDebug("Pong! The gateway latency is {millisecondTime}ms.", ctx.Client.Ping);
        return Task.CompletedTask;
    }
}
