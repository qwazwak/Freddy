using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus;
using DSharpPlus.EventArgs;
using FreddyBot.Core.Services;

namespace FreddyBot.Discord.Handlers;

public sealed class AtFreddyHandler : MessageCreatedEventHandler
{
    public override Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (args.Message.Content.StartsWith("@FreddyBot"))
            return args.Message.RespondAsync("what do you want?");

        return Task.CompletedTask;
    }
}
