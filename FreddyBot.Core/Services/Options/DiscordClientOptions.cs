using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FreddyBot.Core.Services.Options;

public class DiscordClientOptions : IOptions<DiscordClientOptions>
{
    private const string TokenKey = "DISCORD_TOKEN_FREDDY";
    private readonly ILogger<DiscordClientOptions> logger;
    private string discordToken = default!;

    public DiscordClientOptions(ILogger<DiscordClientOptions> logger) => this.logger = logger;

    [ConfigurationKeyName(TokenKey)]
    public string DiscordToken
    {
        get
        {
            if (string.IsNullOrWhiteSpace(discordToken))
                logger.LogError("Error! Discord token (key: {key}) was not found!", discordToken);
            return discordToken;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                logger.LogWarning("Discord token (key: {key}) is being set to a null/whitespace value", discordToken);
            discordToken = value;
        }
    }

    DiscordClientOptions IOptions<DiscordClientOptions>.Value => this;
}
