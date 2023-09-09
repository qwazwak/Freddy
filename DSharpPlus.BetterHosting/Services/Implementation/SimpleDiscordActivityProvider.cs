using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation;

public class SimpleDiscordActivityProvider : IDiscordActivityProvider
{
    private readonly DiscordActivity activity;
    public SimpleDiscordActivityProvider(IOptions<DiscordActivity> activity) => this.activity = activity.Value;

    public ValueTask<DiscordActivity> GetActivity(CancellationToken cancellationToken) => ValueTask.FromResult(activity);
}