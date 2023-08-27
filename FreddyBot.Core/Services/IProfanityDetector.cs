namespace FreddyBot.Core.Services;

public interface IProfanityDetector
{
    public bool ContainsProfanity(string text);
}
