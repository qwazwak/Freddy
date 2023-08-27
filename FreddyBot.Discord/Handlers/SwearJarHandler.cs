using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.Extensions.Logging;
using DSharpPlus;
using DSharpPlus.EventArgs;
using FreddyBot.Core.Services;

namespace FreddyBot.Discord.Handlers;

// Inherit from BaseCommandModule so that CommandsNext can recognize this class as a command.
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

    public override Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        string message = args.Message.Content;
        if (!profanityDetector.ContainsProfanity(message))
            return Task.CompletedTask;

        logger.LogInformation("User \"{author}\" said a bad word! The swear jar will be updated.", args.Author.Username);
        return swearJar.AddSwear();
    }
}
