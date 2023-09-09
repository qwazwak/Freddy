using System.IO;
using System;

namespace DSharpPlus.BetterHosting.Files.Options;

public class BotDataPathOptions
{
    public virtual string FolderPath { get; set; } = default!;
}

public class BotDefaultDataPathOptions : BotDataPathOptions
{
    public string DefaultDataSourceFolder { get; set; } = "BotDefaultData";
    public override string FolderPath => Path.Combine(Directory.GetCurrentDirectory(), DefaultDataSourceFolder);
}

public class BotDataPathBySpecialOptions : BotDataPathOptions
{
    private string? botFolderPath;

    public Environment.SpecialFolder SpecialBaseFolder { set => BaseFolderPath = Environment.GetFolderPath(value); }

    public string BaseFolderPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    public string FreddyFolderName { get; set; } = "BotData";
    public override string FolderPath { get => botFolderPath ?? Path.Combine(BaseFolderPath, FreddyFolderName); set => botFolderPath = value; }
}