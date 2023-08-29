using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using FreddyBot.Core.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FreddyBot.Core.Services.Hosted;

public class DiscordClientHost : BackgroundService
{
    private readonly ILogger<DiscordClient> logger;
    private readonly DiscordClient client;
    private SystemSetupRunner? setupRunner;
    private IServiceProvider provider;

    public DiscordClientHost(ILogger<DiscordClient> logger, DiscordClient client, SystemSetupRunner setupRunner, IServiceProvider provider)
    {
        this.logger = logger;
        this.client = client;
        this.setupRunner = setupRunner;
        this.provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Debug.Assert(setupRunner != null);
        await setupRunner.Run(stoppingToken);
        setupRunner = null;

        // We can specify a status for our bot. Let's set it to "online" and set the activity to "with fire".
        DiscordActivity status = new("with fire", ActivityType.Playing);

        try
        {
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