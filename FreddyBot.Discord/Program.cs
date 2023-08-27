using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;
using DSharpPlus;
using FreddyBot.Core.Services.Implementation;
using FreddyBot.Core.Services;
using FreddyBot.Discord.Handlers;

namespace FreddyBot.Discord;

public sealed class Program
{
    // Remember to make your main method async! You no longer need to have both a Main and MainAsync method in the same class.
    public static async Task Main()
    {
        DiscordClient client = Build(new EnvironmentSecretProvider());

        // We can specify a status for our bot. Let's set it to "online" and set the activity to "with fire".
        DiscordActivity status = new("with fire", ActivityType.Playing);

        // Now we connect and log in.
        await client.ConnectAsync(status, UserStatus.Online);

        // And now we wait infinitely so that our bot actually stays connected.
        await Task.Delay(-1);
    }

    public static DiscordConfiguration BuildDiscordConfiguration(ISecretProvider EnvConfig) => new()
        {
            Token = EnvConfig.DiscordToken,

            // We're asking for unprivileged intents, which means we won't receive any member or presence updates.
            // Privileged intents must be enabled in the Discord Developer Portal.
            TokenType = TokenType.Bot,
            GatewayCompressionLevel = GatewayCompressionLevel.Stream,
            MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,

            // TODO: Enable the message content intent in the Discord Developer Portal.
            // The !ping command will not work without it.
            Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
        };
    public static DiscordClient Build(ISecretProvider EnvConfig) => Build(BuildDiscordConfiguration(EnvConfig));

    public static DiscordClient Build(DiscordConfiguration config)
    {
        DiscordClient client = new(config);
        Configure(client);
        return client;
    }
    public static void Configure(DiscordClient client)
    {
        // Register Random as a singleton. This will be used by the random command.
        ServiceCollection serviceCollection = new();
        ConfigureServices(serviceCollection);
        ServiceProvider provider = serviceCollection.BuildServiceProvider();
        BindEvents(client, provider);

        // Register CommandsNext
        CommandsNextExtension commandsNext = client.UseCommandsNext(new()
        {
            // Add the service provider which will allow CommandsNext to inject the Random instance.
            Services = provider,
            StringPrefixes = new[] { "!" }
        });

        // Register commands
        // CommandsNext will search the assembly for any classes that inherit from BaseCommandModule and register them as commands.
        commandsNext.RegisterCommands(typeof(Program).Assembly);
        
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();
        //services.AddDbContext<FreddyBotContext>();
        services.AddSingleton(Random.Shared); // We're using the shared instance of Random for simplicity.

        services.AddSingleton<ISwearJar, FileSwearJar>();
        //services.AddSingleton<ISwearJar, DbSwearJar>();

        services.AddScoped<IProfanityDetector, ProfanityToolsDetector>();

        services.AddAllHandlers();
    }

    public static void BindEvents(DiscordClient client, IServiceProvider provider)
    {/*
        client.MessageCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            try
            {

                SwearJarHandler handler = scope.ServiceProvider.GetRequiredService<SwearJarHandler>();
                await handler.OnMessageCreated(client, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        };*/
        EventBinder.BindMessageCreated<SwearJarHandler>(client, provider);
    }
}