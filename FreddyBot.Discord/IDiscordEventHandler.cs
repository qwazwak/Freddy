using DSharpPlus.EventArgs;
using DSharpPlus;
using System.Threading.Tasks;
using System;

namespace FreddyBot.Discord;

public interface IDiscordEventHandler
{
}
/*
public interface IDiscordEventHandler<TArgs> where TArgs : DiscordEventArgs
{
    public Task OnEvent(DiscordClient client, TArgs args);
}*/
//public abstract class DiscordEventHandler : IDiscordEventHandler { }
public abstract class DiscordEventHandler<TArgs> /*: DiscordEventHandler, IDiscordEventHandler<TArgs>*/ where TArgs : DiscordEventArgs
{
    public abstract Task OnEvent(DiscordClient client, TArgs args);
}