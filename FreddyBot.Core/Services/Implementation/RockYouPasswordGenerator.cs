using System;
using System.Threading.Tasks;
using System.Collections.Immutable;
using QLib.Extensions;

namespace FreddyBot.Core.Services.Implementation;

public class RockYouPasswordGenerator : IPasswordGenerator
{
    private readonly RockYouPasswordFile rockYouProvider;
    private readonly Random rng;
    private ValueTask<ImmutableArray<string>> RockYou => rockYouProvider.GetFile();

    public RockYouPasswordGenerator(RockYouPasswordFile rockYouProvider, Random rng)
    {
        this.rng = rng;
        this.rockYouProvider = rockYouProvider;
    }

    ValueTask<string> IPasswordGenerator.GeneratePassword(int length, bool includeNumbers, bool includeSpecialChars) => GeneratePassword();
    public ValueTask<string> GeneratePassword() => RockYou.ContinueAfterWith(list => list[rng.Next(0, list.Length)]);
}