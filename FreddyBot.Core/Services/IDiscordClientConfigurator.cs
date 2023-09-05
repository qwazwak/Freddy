using System.Threading.Tasks;
using DSharpPlus;

namespace FreddyBot.Core.Services;

public interface IDiscordClientConfigurator
{
    public void Configure(DiscordClient client);

    public Task ConfigureSharded(DiscordShardedClient shard);
}