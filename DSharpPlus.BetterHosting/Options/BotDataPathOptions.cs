//TODO:
#if false
using System.IO;
using System;

namespace DSharpPlus.BetterHosting.Options;
#if false
public class FileProviderOptionsbackup : IOptions<FileProviderOptionsbackup>
{
    private const string DefaultDataFolder = "FreddyDefaultData";
    private const Environment.SpecialFolder DefaultSpecialBaseFolder = Environment.SpecialFolder.LocalApplicationData;

    public Environment.SpecialFolder SpecialBaseFolder { set => BaseFolderPath = Environment.GetFolderPath(value); }

    public string BaseFolderPath { get; set; } = Environment.GetFolderPath(DefaultSpecialBaseFolder);
    public string FreddyFolderName => "FreddyData";
    public string FreddyFolderPath => Path.Combine(BaseFolderPath, FreddyFolderName);

    public string DBFileName => DefaultDBFileName;
    public string DBFilePath => MapPath(DBFileName);
    public string DefaultDBFileName => "Freddy.db";
    public string DefaultDBFilePath => Path.Combine(DefaultDataFolder, DefaultDBFileName);

    public string MapPath(params string[] segments) => Path.Combine(FreddyFolderPath, Path.Combine(segments));
    FileProviderOptionsbackup IOptions<FileProviderOptionsbackup>.Value => this;
}
#endif

public class BotDataPathOptions
{
    public virtual string FreddyFolderPath { get; set; } = default!;
}

public class BotDefaultDataPathOptions : BotDataPathOptions
{
    public string DefaultDataSourceFolder { get; set; } = "FreddyDefaultData";
    public override string FreddyFolderPath => Path.Combine(Directory.GetCurrentDirectory(), DefaultDataSourceFolder);
}

public class BotDataPathBySpecialOptions : BotDataPathOptions
{
    private string? freddyFolderPath;

    public Environment.SpecialFolder SpecialBaseFolder { set => BaseFolderPath = Environment.GetFolderPath(value); }

    public string BaseFolderPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    public string FreddyFolderName { get; set; } = "FreddyData";
    public override string FreddyFolderPath { get => freddyFolderPath ?? Path.Combine(BaseFolderPath, FreddyFolderName); set => freddyFolderPath = value; }
}
#endif