using System;
using System.Threading.Tasks;
using DSharpPlus;
using FreddyBot.Core.Services.Options;
using FreddyBot.Core.Services;
using FreddyBot.Core.Services.Implementation;
using FreddyBot.Core.Services.Implementation.Configuration;
using FreddyBot.Core.Services.Hosted;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using DSharpPlus.EventsBinderExtension;

namespace FreddyBot.Core;

public class Program
{
    public static async Task Main(string[]? args)
    {
        IHost host = Build(args);

        await host.RunAsync();
    }

    public static IHost Build(string[]? args) => GetBuilder(args).Build();

    public static HostApplicationBuilder GetBuilder(string[]? args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        ConfigureServices(builder.Services);

        return builder;
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();

        services.AddOptions();
        services.AddHttpClient();

        services.AddOptions<FileProviderOptions>();
        services.AddOptions<DiscordClientOptions>();

        services.AddTransient<SystemSetupRunner>();

        services.AddTransient<ISystemSetup, RequiredFileSetup>();

        services.AddTransient<IDiscordClientConfigurator, CommandsNextDiscordClientConfiguration>();
        services.AddTransient<IDiscordClientConfigurator, ConfigureDiscordClientEvents>();
        services.AddTransient<DiscordConfiguration>((sp) =>
        {
            DiscordClientOptions options = sp.GetRequiredService<IOptions<DiscordClientOptions>>().Value;

            return new()
            {
                Token = options.DISCORD_TOKEN_FREDDY ?? throw new ArgumentException("Error! Discord token was not found!"),

                // We're asking for unprivileged intents, which means we won't receive any member or presence updates.
                // Privileged intents must be enabled in the Discord Developer Portal.
                TokenType = TokenType.Bot,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,

                // TODO: Enable the message content intent in the Discord Developer Portal.
                // The !ping command will not work without it.
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            };
        });
        services.AddSingleton<DiscordClient>((sp) =>
        {
            DiscordConfiguration config = sp.GetRequiredService<DiscordConfiguration>();
            DiscordClient client = new(config);

            foreach (IDiscordClientConfigurator configurator in sp.GetServices<IDiscordClientConfigurator>())
                configurator.Configure(client);

            return client;
        });

        services.AddSingleton(Random.Shared); // We're using the shared instance of Random for simplicity.
        
        services.AddDbContext<FreddyBotContext>(opt => opt.UseSqlite());
        services.AddTransient<ISwearJar, DbSwearJar>();
        //services.AddSingleton<ISwearJar, FileSwearJar>();

       // services.AddScoped<IProfanityDetector, ProfanityToolsDetector>();

        services.AddScoped<IProfanityDetector, ApiNinja>();
        services.AddScoped<ISentimentAnalyzer, ApiNinja>();
        services.AddScoped<IPasswordGenerator, ApiNinja>();

        services.AddHostedService<DiscordClientHost>();

        services.AddEventsNextHandlers(typeof(Program).Assembly);
    }
}
