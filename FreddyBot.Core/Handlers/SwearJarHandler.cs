using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus;
using DSharpPlus.EventArgs;
using FreddyBot.Core.Services;
using DSharpPlus.EventsBinderExtension.Entities;

namespace FreddyBot.Core.Handlers;

public sealed class SwearJarHandler : MessageCreatedEventHandler
{
    private readonly ILogger<SwearJarHandler> logger;
    private readonly ISwearJar swearJar;
    private readonly IProfanityDetector profanityDetector;

    public SwearJarHandler(ILogger<SwearJarHandler> logger, ISwearJar swearJar, IProfanityDetector profanityDetector)
    {
        this.logger = logger;
        this.swearJar = swearJar;
        this.profanityDetector = profanityDetector;
    }

    public override async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (args.Message.Author.IsBot)
            return;

        string message = args.Message.Content;
        if (await profanityDetector.ContainsProfanity(message))
        {
            logger.LogInformation("User \"{author}\" said a bad word! The swear jar will be updated.", args.Author.Username);
            await swearJar.IncrementJar(args.Channel.Guild.Id);
        }
    }
}
