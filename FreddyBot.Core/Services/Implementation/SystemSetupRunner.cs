using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FreddyBot.Core.Services.Implementation;

public sealed class SystemSetupRunner
{
    private readonly ILogger<DiscordClient> logger;
    private readonly IServiceProvider provider;
    private bool hasRun;

    public SystemSetupRunner(ILogger<DiscordClient> logger, IServiceProvider provider)
    {
        this.logger = logger;
        this.provider = provider;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        if(hasRun)
            throw new InvalidOperationException("AlreadyRun");
        logger.LogDebug("Starting running of setup tasks");
        Stopwatch sw = Stopwatch.StartNew();
        await using AsyncServiceScope scope = provider.CreateAsyncScope();
        IEnumerable<ISystemSetup> setups = scope.ServiceProvider.GetServices<ISystemSetup>();
        await Task.WhenAll(setups.Select(setup => setup.Run(cancellationToken)));
        sw.Stop();
        logger.LogInformation("Setup took {elapsed}", sw.Elapsed);
        hasRun = true;
    }
}
