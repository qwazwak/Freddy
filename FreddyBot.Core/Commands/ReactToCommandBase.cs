using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DiscordExtensions;

namespace FreddyBot.Core.Commands;

public abstract class ReactToCommandBase : BaseCommandModule
{
    protected abstract IEnumerable<string> ReactionStrings { get; }
    protected virtual IEnumerable<DiscordEmoji> ReactionEmoji => ReactionStrings.Select(DiscordEmoji.FromUnicode);
    private static DiscordEmoji[] reactionEmoji = null!;
    protected ReactToCommandBase()
    {
        if (reactionEmoji == null)
            Interlocked.CompareExchange(ref reactionEmoji, ReactionEmoji.ToArray(), null);
    }

    protected virtual string NotFoundMessage(ulong messageid) => "huh? i cannot find a message with ID {0}";

    protected async Task ReactTo(CommandContext context, ulong messageid)
    {
        DiscordMessage? relatedMessage = await context.Channel.GetMessageOrNullAsync(messageid);
        if (relatedMessage != null)
        {
            await context.TriggerTypingAsync();
            //await interaction.deferReply({ ephemeral: true});
            foreach (DiscordEmoji emote in reactionEmoji)
                await relatedMessage.CreateReactionAsync(emote);
        }
        else
        {
            await context.RespondAsync(NotFoundMessage(messageid));
        }
    }
}