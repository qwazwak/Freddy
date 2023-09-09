//TODO:
#if false
namespace DSharpPlus.BetterHosting.Options;

public class BotDataFileNameOptions
{
    private string? defaultDBFileName;
    public string DefaultDBFileName
    {
        get => defaultDBFileName ?? DBFileName;
        set => defaultDBFileName = value;
    }
    public string DBFileName { get; set; } = "Freddy.db";
}

#endif