using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Hosted;

public class DiscordClientHost : BackgroundService
{
    private readonly ILogger<DiscordClientHost> logger;
    private readonly DiscordClient client;
    private readonly IDiscordActivityProvider activityProvider;

    public DiscordClientHost(ILogger<DiscordClientHost> logger, DiscordClient client, IDiscordActivityProvider activityProvider )
    {
        this.logger = logger;
        this.client = client;
        this.activityProvider = activityProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        DiscordActivity status = await activityProvider.GetActivity(stoppingToken);

        try
        {
            logger.LogTrace("Connecting to discord...");

            await client.ConnectAsync(status, UserStatus.Online);
        }
        catch (Exception ex)
        {
            // Now we connect and log in.
            logger.LogError(ex, "Unable to connect because of {message}", ex.Message);
            throw;
        }

        // And now we wait infinitely so that our bot actually stays connected.
        await Task.Delay(-1, stoppingToken);
    }
}