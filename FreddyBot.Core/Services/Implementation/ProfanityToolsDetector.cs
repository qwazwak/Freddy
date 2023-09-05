using System.Threading.Tasks;
using FreddyBot.Core.Services;
using FreddyBot.Core.Services.Implementation;

namespace FreddyBot.Core.Services.Implementation;

public class ProfanityToolsDetector : IProfanityDetector
{
    private readonly SimpleSwearDetector filter = new();
    public bool ContainsProfanity(string text) => filter.ContainsSwear(text);
    ValueTask<bool> IProfanityDetector.ContainsProfanity(string text) => new(ContainsProfanity(text));
}