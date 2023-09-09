using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace DSharpPlus.BetterHosting.Services;

public interface IDiscordActivityProvider
{
    public ValueTask<DiscordActivity> GetActivity(CancellationToken cancellationToken);
}