using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting.Services;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DSharpPlus.BetterHosting.Hosting;

/// <summary>
/// A program abstraction.
/// </summary>
internal sealed class HostStartupWrapper : IHost
{
    private readonly IHost host;
    private bool disposedValue;

    public IServiceProvider Services => host.Services;

    public HostStartupWrapper(IHost host) => this.host = host;

    private async Task RunSetup(CancellationToken cancellationToken)
    {
        Stopwatch sw = Stopwatch.StartNew();
        await using AsyncServiceScope scope = Services.CreateAsyncScope();
        ILogger<HostStartupWrapper>? logger = scope.ServiceProvider.GetService<ILogger<HostStartupWrapper>>();
        logger?.LogDebug("Starting running of setup tasks");

        IEnumerable<IAsyncSystemSetup> asyncSetup = scope.ServiceProvider.GetServices<IAsyncSystemSetup>();

        Task allAsync = Task.WhenAll(asyncSetup.Select(setup => setup.Run(cancellationToken)));

        //sync
        {
            IEnumerable<ISystemSetup> syncSetup = scope.ServiceProvider.GetServices<ISystemSetup>();
            Parallel.ForEach(syncSetup, setup => setup.Run(cancellationToken));
        }

        await allAsync;
        sw.Stop();
        logger?.LogInformation("Finished setup in {elapsed}", sw.Elapsed);
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        await RunSetup(cancellationToken);
        await host.StartAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken = default) => host.StopAsync(cancellationToken);

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
                // dispose managed state (managed objects)
                host.Dispose();

            // free unmanaged resources (unmanaged objects) and override finalizer
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
