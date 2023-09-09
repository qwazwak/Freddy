using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services;

public interface IDiscordClientConfigurator
{
    public ValueTask Configure(DiscordClient client);

    public Task ConfigureSharded(DiscordShardedClient shard);
}