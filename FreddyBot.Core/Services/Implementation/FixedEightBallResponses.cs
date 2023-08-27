using System;
using System.Security.Cryptography;
using FreddyBot.Core.Services;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace FreddyBot.Core.Services.Implementation;

public enum AnswerClass
{
    Affirmative,
    NonCommittal,
    Negative
}
public class FixedEightBallResponses : IEightBallResponseStore
{
    public IEightBallHasher Hasher { get; set; } = default!;
    static ReadOnlySpan<string> Responses => new string[]
    {
        "As I see it, yes.",
        "Ask again later.",
        "Better not tell you now.",
        "Cannot predict now.",
        "Concentrate and ask again.",
        "Don’t count on it.",
        "It is certain.",
        "It is decidedly so.",
        "Most likely.",
        "My reply is no.",
        "My sources say no.",
        "Outlook not so good.",
        "Outlook good.",
        "Reply hazy, try again.",
        "Signs point to yes.",
        "Very doubtful.",
        "Without a doubt.",
        "Yes.",
        "Yes – definitely.",
        "You may rely on it."
    };

    public int Count => Responses.Length;

    public string GetResponse(string question)
    {
        int index = Hasher.Hash(question) % Responses.Length;
        return Responses[index];
    }

    public string AtIndex(int index) => Responses[index];
    public string ByHash(int hash)
    {
        double val = hash / (double)int.MaxValue;
        int resNum = (int)Math.Floor(val * Responses.Length);
        string res = Responses[resNum];
        return res;
    }
}
