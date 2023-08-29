using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using FreddyBot.Core.Services;
using DSharpPlus.EventsBinderExtension.Entities;

namespace FreddyBot.Core.Handlers;

public sealed class AtFreddyHandler : MessageCreatedEventHandler
{
    private const string AtMe = "<@882979290411573278>";
    private readonly ISentimentAnalyzer sentimentAnalyzer;

    public AtFreddyHandler(ISentimentAnalyzer sentimentAnalyzer)
    {
        this.sentimentAnalyzer = sentimentAnalyzer;

    }
    public override Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (args.Message.Content.Equals(AtMe, System.StringComparison.InvariantCultureIgnoreCase))
            return args.Message.RespondAsync("what do you want?");
        else if (args.Message.Content.Contains(AtMe, System.StringComparison.InvariantCultureIgnoreCase))
            return Analyze(client, args);
        else if (args.Message.Content.Equals("bitch", System.StringComparison.InvariantCultureIgnoreCase))
            return args.Message.RespondAsync("im here");

        return Task.CompletedTask;
    }

    readonly double SentimateRangeOuter = 0.45;
    readonly double SentimateRangeInner = 0.10;
    private async Task Analyze(DiscordClient _, MessageCreateEventArgs args)
    {
        await args.Channel.TriggerTypingAsync();

        string rest = args.Message.Content.Replace(AtMe, string.Empty);
        double sentiment = await sentimentAnalyzer.AnalyzeSentiment(rest);
        if (sentiment > SentimateRangeInner)
        {
            if(sentiment > SentimateRangeOuter)
                await args.Message.RespondAsync("aww thanks <3");
            else
                await args.Message.RespondAsync("thanks");
        }
        else if (sentiment < -SentimateRangeInner)
        {
            if (sentiment < -SentimateRangeOuter)
                await args.Message.RespondAsync("fuck you too!");
            else
                await args.Message.RespondAsync("cmon");
        }
        else
        {

            await args.Message.RespondAsync("alright i guess");
        }
    }
}
