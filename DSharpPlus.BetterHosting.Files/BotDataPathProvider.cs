using System.IO;
using DSharpPlus.BetterHosting.Files.Options;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Files;

public abstract class BotDataPathProvider
{
    public string FreddyFolderPath => options.FolderPath;
    private readonly BotDataPathOptions options;

    protected BotDataPathProvider(IOptions<BotDataPathOptions> options) : this(options.Value) { }
    protected BotDataPathProvider(BotDataPathOptions options) => this.options = options;

    public string MapPath(string path) => Path.Combine(FreddyFolderPath, path);
    public string MapPath(string path1, string path2) => Path.Combine(FreddyFolderPath, path1, path2);
    public string MapPath(string path1, string path2, string path3) => Path.Combine(FreddyFolderPath, path1, path2, path3);
    public string MapPath(string path1, string path2, string path3, string path4) => Path.Combine(FreddyFolderPath, path1, path2, path3, path4);

    public string MapPath(params string[] segments) => Path.Combine(FreddyFolderPath, Path.Combine(segments));
}
