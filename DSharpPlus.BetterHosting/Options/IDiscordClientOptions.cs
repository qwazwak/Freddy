using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Options;

public interface IDiscordClientOptions
{
    public string DiscordToken { get; set; }
    public DiscordIntents Intents { get; set; }
    public GatewayCompressionLevel GatewayCompressionLevel { get; set; }
    public LogLevel MinimumLogLevel { get; set; }
}
