using System;
using System.IO;
using Microsoft.Extensions.Options;

namespace FreddyBot.Core.Services.Implementation;

public class FileProviderOptions : IOptions<FileProviderOptions>
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
    FileProviderOptions IOptions<FileProviderOptions>.Value => this;
}
