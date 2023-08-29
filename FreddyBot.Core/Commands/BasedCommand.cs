using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FreddyBot.Core.Commands;

public sealed class BasedCommand : ReactToCommandBase
{
    protected override IEnumerable<string> ReactionStrings { get; } = new string[]
    {
        "🅱",
        "🇦",
        "🇸",
        "🇪",
        "🇩"
    };
    protected override string NotFoundMessage(ulong messageid) => $"what is based? no really, i cannot find a message with ID {messageid}";

    [Command("based")]
    [Description("React to a message with based")]
    public Task BasedAsync(CommandContext context, [Description("The message ID you wish to BASED"), Required] ulong messageid)
            => ReactTo(context, messageid);
}
