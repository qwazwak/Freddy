using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FreddyBot.Core.Services.Options;

public class DiscordClientOptions : IOptions<DiscordClientOptions>
{
    private const string TokenKey = "DISCORD_TOKEN_FREDDY";
    private string discordToken = default!;

    [ConfigurationKeyName(TokenKey)]
    public string DISCORD_TOKEN_FREDDY
    {
        get
        {
            if (string.IsNullOrWhiteSpace(discordToken))
                Console.Error.WriteLine($"Error! Discord token (key: {discordToken ?? "null"}) was not found!");
            return "ODgyOTc5MjkwNDExNTczMjc4.GdwTfv.pxpaGfaW_qkznIeopysjI4NRt44SDjMCKDAbLY";
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                Console.Error.WriteLine("Discord token (key: {key}) is being set to a null/whitespace value", discordToken);
            discordToken = value;
        }
    }

    DiscordClientOptions IOptions<DiscordClientOptions>.Value => this;
}
