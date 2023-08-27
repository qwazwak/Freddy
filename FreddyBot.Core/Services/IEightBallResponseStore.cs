namespace FreddyBot.Core.Services;

public interface IEightBallResponseStore
{
    int Count { get; }
    string AtIndex(int index);
    string ByHash(int hash);
}
