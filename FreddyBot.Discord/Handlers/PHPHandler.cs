using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using FuzzySharp;

namespace FreddyBot.Discord.Handlers;

public sealed class PHPHandler : MessageCreatedEventHandler
{
    public double percentChance;
    public double fractionalChance;
    
    public double PercentChance { get => percentChance; set => (percentChance, fractionalChance) = (value, value / 100.0); }
    public double FractionalChance { get => fractionalChance; set => (percentChance, fractionalChance) = (value * 100.0, value); }

    public PHPHandler(double percentChance) => PercentChance = percentChance;

    public PHPHandler() : this(0.01) { }

    public override async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        string messageContent = args.Message.Content;
        if (!messageContent.Contains("php", StringComparison.InvariantCultureIgnoreCase))
            return;
        await args.Channel.TriggerTypingAsync();

        int ratio = Fuzz.Ratio(messageContent, "php is a good programming language", FuzzySharp.PreProcess.PreprocessMode.Full);

        if (ratio >= 80)
            await args.Message.RespondAsync("False");
    }
}
