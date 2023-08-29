using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace FreddyBot.Core.Services.Implementation.Configuration;

public class CommandsNextDiscordClientConfiguration : IDiscordClientConfigurator
{
    private readonly IServiceProvider provider;
    public CommandsNextDiscordClientConfiguration(IServiceProvider provider) => this.provider = provider;

    public void Configure(DiscordClient client)
    {
        // Register CommandsNext
        CommandsNextExtension commandsNext = client.UseCommandsNext(new()
        {
            // Add the service provider which will allow CommandsNext to inject the Random instance.
            Services = provider,
            StringPrefixes = new[] { "!", "/" }
        });

        // Register commands
        // CommandsNext will search the assembly for any classes that inherit from BaseCommandModule and register them as commands.
        commandsNext.RegisterCommands(typeof(Program).Assembly);
    }
}
