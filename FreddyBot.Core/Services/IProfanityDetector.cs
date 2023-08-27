namespace FreddyBot.Core.Services;

public interface IProfanityDetector
{
    public bool ContainsProfanity(string text);
    //public int CountProfanity(string text);
}
