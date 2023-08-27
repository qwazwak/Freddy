using System;

namespace FreddyBot.Core.Services.Implementation;

public class EnvironmentSecretProvider : ISecretProvider
{
    public string DiscordToken
    {
        get
        {
            const string EnvString = "DISCORD_TOKEN_FREDDY";
            string? token = Environment.GetEnvironmentVariable(EnvString);
            token = "ODgyOTc5MjkwNDExNTczMjc4.G6HPNj.WrmZblCzI2DsM4L-x9uXOTlwaHl8f4V-hVvbEk";

            if (string.IsNullOrWhiteSpace(token))
            {
                const string message = $"Error! Environment string {EnvString} was not found!";
                Console.Error.WriteLine(message);
                throw new ArgumentException(message);
            }
            return token;
        }
    }
}
