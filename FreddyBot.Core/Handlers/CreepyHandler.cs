using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using DSharpPlus.EventsBinderExtension.Entities;

namespace FreddyBot.Core.Handlers;

public sealed class CreepyHandler : MessageCreatedEventHandler
{
    private readonly ILogger<SwearJarHandler> logger;
    private readonly Random rng;

    public double percentChance;
    public double fractionalChance;

    public double PercentChance { get => percentChance; set => (percentChance, fractionalChance) = (value, value / 100.0); }
    public double FractionalChance { get => fractionalChance; set => (percentChance, fractionalChance) = (value * 100.0, value); }

    public CreepyHandler(ILogger<SwearJarHandler> logger, Random rng)
    {
        PercentChance = 0.01;
        this.logger = logger;
        this.rng = rng;
    }

    public override Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        double value = rng.NextDouble();
        if (value <= FractionalChance)
        {
            logger.LogInformation("Chance of {PercentChance} for creepy hit with value of {value}", PercentChance, value);
            return args.Channel.SendMessageAsync("I see all 👀");
        }
        return Task.CompletedTask;
    }
}