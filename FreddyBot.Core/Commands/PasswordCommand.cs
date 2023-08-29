using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using FreddyBot.Core.Services;

namespace FreddyBot.Core.Commands;

public sealed class PasswordCommand : BaseCommandModule
{
    private readonly IPasswordGenerator generator;

    public PasswordCommand(IPasswordGenerator generator) => this.generator = generator;

    // Register the method as a command, specifying the name and description.
    // Unfortunately, CommandsNext does not support static methods.
    [Command("password"), Description("Pings the bot and returns the gateway latency.")]
    [Aliases("makepass", "genpassword")]
    public async Task GeneratePasswordAsync(CommandContext ctx, int length = 8, bool includeNumbers = true, bool includeSpecialChars = true)
    {
        await ctx.Channel.TriggerTypingAsync();
        string password = await generator.GeneratePassword(length, includeNumbers, includeSpecialChars);
        await ctx.RespondAsync($"Heres a password you can use, be sure to keep it secret! `{password}`");
    }
}
