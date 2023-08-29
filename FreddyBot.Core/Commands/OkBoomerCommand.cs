 using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace FreddyBot.Core.Commands;

public sealed class OkBoomerCommand : BaseCommandModule
{
    static readonly DiscordEmoji[] OkBoomerEmoji = new DiscordEmoji[]{
        DiscordEmoji.FromUnicode("🆗"),
        DiscordEmoji.FromUnicode("🅱️"),
        DiscordEmoji.FromUnicode("🇴"),
        DiscordEmoji.FromUnicode("🅾️"),
        DiscordEmoji.FromUnicode("🇲"),
        DiscordEmoji.FromUnicode("🇪"),
        DiscordEmoji.FromUnicode("🇷"),
    };

    [Command("okBoomer"), Description("Pings the bot and returns the gateway latency."), Aliases("ok")]
    public async Task OkBoomerAsync(CommandContext context)
    {
        //        ulong msgID = context.Message.Id;
        DiscordMessage targetMsg = context.Message.ReferencedMessage;
        /*try
        {
            var targetMsg = await interaction.channel.messages.fetch(msgID);
        }
        catch (e)
        {
            msg.reply("That is an invalid message ID or it is not in this channel.");
            return;
        }*/
        await context.TriggerTypingAsync();
        //await interaction.deferReply({ ephemeral: true});
        foreach (DiscordEmoji emote in OkBoomerEmoji)
            await targetMsg.CreateReactionAsync(emote);

        //interaction.editReply({ content: "Done", ephemeral: true});

        // The CommandContext provides access to the DiscordClient, the message, the channel, etc.
        // If the CommandContext is not provided as a parameter, CommandsNext will ignore the method.
        // Additionally, without the CommandContext, it would be impossible to respond to the user.
        await context.RespondAsync($"Pong! The gateway latency is {context.Client.Ping}ms.");
    }
}
