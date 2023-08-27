using FreddyBot.Core.Services;
using System;
using System.Security.Cryptography;
using System.Text;

namespace FreddyBot.Core.Services.Implementation;

public class MD5EightBallHasher : IEightBallHasher
{
    int IEightBallHasher.Hash(string question) => Hash(question);
    public static int Hash(string question)
    {
        byte[] questionUTF8 = Encoding.UTF8.GetBytes(question);
        return Hash(questionUTF8);
    }

    public static int Hash(byte[] questionUTF8)
    {
        byte[] hashBytes = MD5.HashData(questionUTF8);
        HashCode hash = new();
        hash.AddBytes(hashBytes);
        int result = hash.ToHashCode();
        return result;
    }
}
