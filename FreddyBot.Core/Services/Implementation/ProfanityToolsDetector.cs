﻿using System.Threading.Tasks;
using FreddyBot.Core.Services;
using ProfanityFilterTools;

namespace FreddyBot.Core.Services.Implementation;

public class ProfanityToolsDetector : IProfanityDetector
{
    private readonly ProfanityFilter filter = new();
    public bool ContainsProfanity(string text) => filter.ContainsProfanity(text);
    ValueTask<bool> IProfanityDetector.ContainsProfanity(string text) => new(ContainsProfanity(text));
}