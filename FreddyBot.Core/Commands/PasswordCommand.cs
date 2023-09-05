using System.Threading.Tasks;
using FreddyBot.Core.Services;
using DSharpPlus.SlashCommands;
using DiscordExtensions;

namespace FreddyBot.Core.Commands;

public sealed class PasswordCommand : ApplicationCommandModule
{
    private readonly IPasswordGenerator generator;

    public PasswordCommand(IPasswordGenerator generator) => this.generator = generator;

    [SlashCommand("GeneratePassword", "Passwords the bot and returns the gateway latency.")]
    public async Task PasswordAsync(InteractionContext ctx, [Option(nameof(length), "")] int length = 8, [Option(nameof(length), "")] bool includeNumbers = true, [Option(nameof(length), "")] bool includeSpecialChars = true)
    {
        await ctx.DeferAsync(ephemeral: true);

        Task TypingTask =  ctx.Channel.TriggerTypingAsync();
        ValueTask<string> passwordTask = generator.GeneratePassword(length, includeNumbers, includeSpecialChars);
        await TypingTask;
        string password = await passwordTask;
        await ctx.EditResponseAsync($"Heres a password you can use, be sure to keep it secret! `{password}`");
    }
}