using DSharpPlus;

namespace FreddyBot.Core.Services;

public interface IDiscordClientConfigurator
{
    public void Configure(DiscordClient client);
}