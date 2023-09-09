using DSharpPlus.BetterHosting.Options;
using DSharpPlus;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal class FallbackDiscordConfigurationProvider : IDiscordConfigurationProvider
{
    private readonly IDiscordClientOptions options;
    public FallbackDiscordConfigurationProvider(IOptions<IDiscordClientOptions> options) => this.options = options.Value;

    public DiscordConfiguration GetConfiguration() => new()
    {
        Token = options.DiscordToken,

        // We're asking for unprivileged intents, which means we won't receive any member or presence updates.
        // Privileged intents must be enabled in the Discord Developer Portal.
        TokenType = TokenType.Bot,
        GatewayCompressionLevel = options.GatewayCompressionLevel,
        MinimumLogLevel = options.MinimumLogLevel,

        // TODO: Enable the message content intent in the Discord Developer Portal.
        // The !ping command will not work without it.
        Intents = options.Intents,
    };
}