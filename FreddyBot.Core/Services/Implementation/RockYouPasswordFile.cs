using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Collections.Immutable;
using QLib.Extensions;
using FreddyBot.Core.Services.Options;

namespace FreddyBot.Core.Services.Implementation;

public class RockYouPasswordFile
{
    private readonly Task<ImmutableArray<string>> resultTask;
    public RockYouPasswordFile(IOptions<FileProviderOptions> options)
    {
        resultTask = File.ReadAllLinesAsync(Path.Combine(options.Value.BaseFolderPath, "rockyou.txt")).ContinueAfterWith(ImmutableArray.Create);
    }

    public ValueTask<ImmutableArray<string>> GetFile() => new(resultTask);
}
