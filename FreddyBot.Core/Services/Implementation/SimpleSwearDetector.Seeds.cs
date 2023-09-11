using System;

namespace FreddyBot.Core.Services.Implementation;

public partial class SimpleSwearDetector
{
    private static ReadOnlySpan<string> SwearSeedWords => new string[]
    {
    };
}