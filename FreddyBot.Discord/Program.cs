using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;
using DSharpPlus;
using FreddyBot.Core.Services.Implementation;
using FreddyBot.Core.Services;
using FreddyBot.Discord.Handlers;
using Microsoft.Extensions.Configuration;
using FreddyBot.Core.Services.Options;
using Microsoft.Extensions.Options;

namespace FreddyBot.Discord;

public sealed class Program
{
    // Remember to make your main method async! You no longer need to have both a Main and MainAsync method in the same class.
    public static async Task Main()
    {
        DiscordClient client = Build().GetRequiredService<DiscordClient>();

        // We can specify a status for our bot. Let's set it to "online" and set the activity to "with fire".
        DiscordActivity status = new("with fire", ActivityType.Playing);

        // Now we connect and log in.
        await client.ConnectAsync(status, UserStatus.Online);

        // And now we wait infinitely so that our bot actually stays connected.
        await Task.Delay(-1);
    }

    public static ServiceProvider Build()
    {
        ServiceCollection serviceCollection = new();
        ConfigureServices(serviceCollection);
        ServiceProvider provider = serviceCollection.BuildServiceProvider();
        BindEvents(provider);
        return provider;
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions<DiscordClientOptions>();

        services.AddSingleton((sp) =>
        {
            DiscordClientOptions options = sp.GetRequiredService<IOptions<DiscordClientOptions>>().Value;

            DiscordConfiguration config = new()
            {
                Token = options.DiscordToken ?? throw new ArgumentException("Error! Discord token was not found!"),

                // We're asking for unprivileged intents, which means we won't receive any member or presence updates.
                // Privileged intents must be enabled in the Discord Developer Portal.
                TokenType = TokenType.Bot,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,

                // TODO: Enable the message content intent in the Discord Developer Portal.
                // The !ping command will not work without it.
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            };

            DiscordClient client = new(config);

            // Register CommandsNext
            CommandsNextExtension commandsNext = client.UseCommandsNext(new()
            {
                // Add the service provider which will allow CommandsNext to inject the Random instance.
                Services = sp,
                StringPrefixes = new[] { "!", "/"}
            });

            // Register commands
            // CommandsNext will search the assembly for any classes that inherit from BaseCommandModule and register them as commands.
            commandsNext.RegisterCommands(typeof(Program).Assembly);
            return client;

        });

        services.AddSingleton<IConfiguration>((_) => Configuration.AutoInstance);
        services.AddLogging();
        //services.AddDbContext<FreddyBotContext>();
        services.AddSingleton(Random.Shared); // We're using the shared instance of Random for simplicity.

        services.AddSingleton<ISwearJar, FileSwearJar>();

        services.AddScoped<IProfanityDetector, ProfanityToolsDetector>();

        services.AddAllHandlers();
    }

    private static void BindEvents(IServiceProvider provider)
        => BindEvents(provider.GetRequiredService<DiscordClient>(), provider);

    private static void BindEvents(DiscordClient client, IServiceProvider provider)
    {
        EventBinder.BindMessageCreated<AtFreddyHandler>(client, provider);
        EventBinder.BindMessageCreated<CreepyHandler>(client, provider);
        EventBinder.BindMessageCreated<PHPHandler>(client, provider);
        EventBinder.BindMessageCreated<SwearJarHandler>(client, provider);
    }
}