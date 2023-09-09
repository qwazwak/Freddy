using DSharpPlus.BetterHosting.Files.Options;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Files;

public class DefaultBotDataPathProvider : BotDataPathProvider
{
    public DefaultBotDataPathProvider(IOptions<BotDefaultDataPathOptions> options) : base(options) { }
    public DefaultBotDataPathProvider(BotDefaultDataPathOptions options) : base(options) { }
}
