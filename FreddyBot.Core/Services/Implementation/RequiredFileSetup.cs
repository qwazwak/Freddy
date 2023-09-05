using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Options;
using System.Threading;
using FreddyBot.Core.Services.Implementation.Database;

namespace FreddyBot.Core.Services.Implementation;

#if hardDefault
public class RequiredFileSetup : ISystemSetup
{
    private readonly FileProviderOptions options;

    public RequiredFileSetup(IOptions<FileProviderOptions> options) : this(options.Value) { }
    public RequiredFileSetup(FileProviderOptions options) => this.options = options;

    public Task Run(CancellationToken cancellationToken)
    {
        if(!Path.Exists(options.FreddyFolderPath))
            Directory.CreateDirectory(options.FreddyFolderPath);

        return File.Exists(options.DBFilePath) || cancellationToken.IsCancellationRequested ? Task.CompletedTask : CopyDefaultDBAsync();
    }

    private async Task CopyDefaultDBAsync()
    {
        string sourceFile = options.DefaultDBFilePath;
        string destinationFile = options.DBFilePath;

        //File.Copy(sourceFile, destinationFile);
        using FileStream sourceStream = new(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan);
        using FileStream destinationStream = new(destinationFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan);
        await sourceStream.CopyToAsync(destinationStream);
    }
}
#else
public class RequiredFileSetup : ISystemSetup
{
    private readonly SwearJarContext context;

    public RequiredFileSetup(SwearJarContext context) => this.context = context;

    public async Task Run(CancellationToken cancellationToken) => await context.Database.EnsureCreatedAsync(cancellationToken);
}
#endif