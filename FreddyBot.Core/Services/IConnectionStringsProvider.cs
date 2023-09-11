namespace FreddyBot.Core.Services;

public interface IConnectionStringsProvider
{
    public string? Get(string name);
}
