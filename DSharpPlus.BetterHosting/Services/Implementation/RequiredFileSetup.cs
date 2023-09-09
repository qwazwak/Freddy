/*
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace DSharp.BetterHosting.Services.Implementation;

public class DBSetup : IAsyncSystemSetup
{
    private readonly ILogger<DBSetup> logger;

    public DBSetup(ILogger<DBSetup> logger)
    {
        this.logger = logger;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        await context.Database.EnsureCreatedAsync(cancellationToken);
    }

    private void Check(CancellationToken cancellationToken)
    {
        Assembly? assembly = Assembly.GetEntryAssembly();
        if(assembly == null)
        await context.Database.EnsureCreatedAsync(cancellationToken);
    }
}
*/