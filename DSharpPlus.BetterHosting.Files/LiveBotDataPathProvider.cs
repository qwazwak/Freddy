using DSharpPlus.BetterHosting.Files.Options;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Files;

public class LiveBotDataPathProvider : BotDataPathProvider
{
    public LiveBotDataPathProvider(IOptions<BotDataPathOptions> options) : base(options) { }
    public LiveBotDataPathProvider(BotDataPathOptions options) : base(options) { }
}
