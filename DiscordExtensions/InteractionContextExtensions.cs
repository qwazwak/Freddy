using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace DiscordExtensions;

public static class InteractionContextExtensions
{
    public static async Task EditResponseAsync(this InteractionContext ctx, string message, IEnumerable<DiscordAttachment>? attachments = null)
    {
        ArgumentNullException.ThrowIfNull(ctx);
        ArgumentNullException.ThrowIfNull(message);
        await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent(message), attachments!);
    }
}
