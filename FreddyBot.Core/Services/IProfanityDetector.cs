using System.Threading.Tasks;

namespace FreddyBot.Core.Services;

public interface IProfanityDetector
{
    public ValueTask<bool> ContainsProfanity(string text);
}
