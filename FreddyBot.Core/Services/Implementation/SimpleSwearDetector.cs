using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreddyBot.Core.Services.Implementation;

public sealed partial class SimpleSwearDetector : IProfanityDetector
{

    private readonly HashSet<string> swears = new();

    /// <summary>
    /// Constructor that initializes the standard profanity list.
    /// </summary>
    public SimpleSwearDetector()
    {
        foreach (string word in SwearSeedWords)
            swears.Add(word);
    }

    ValueTask<bool> IProfanityDetector.ContainsProfanity(string text) => ValueTask.FromResult(ContainsSwear(text));

    public bool ContainsSwear(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (string.IsNullOrWhiteSpace(text))
            return false;

        string[] words = text.Split(' ');

        return swears.Overlaps(words);
    }
}