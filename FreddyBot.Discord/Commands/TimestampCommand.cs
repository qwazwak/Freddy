using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using System;
using DSharpPlus;
using System.Diagnostics.CodeAnalysis;

namespace FreddyBot.Discord.Commands;

[Group("timestamp"), Description("Handles timestamp manipulation.")]
public sealed class TimestampCommand : BaseCommandModule
{

    [Command("parse"), Description("Displays when a snowflake was made.")]
    [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Required for DSharpPlus")]
    public async Task ParseAsync(CommandContext context, [Description("The snowflake to grab the creation time from.")] ulong snowflake)
    {
        // Grab the timestamp from the snowflake.
        // If you wish to do this manually: https://discord.com/developers/docs/reference#snowflakes
        DateTimeOffset timestamp = snowflake.GetSnowflakeTime();
        await context.RespondAsync($"The snowflake was created at {Formatter.Timestamp(timestamp, TimestampFormat.RelativeTime)} (hover for exact measurement).");
    }

    [Command("now"), Description("Displays the current snowflake.")]
    [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Required for DSharpPlus")]
    public async Task NowAsync(CommandContext context)
    {
        // Grab the current snowflake.
        // If you wish to do this manually: https://discord.com/developers/docs/reference#snowflakes
        long unixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        await context.RespondAsync($"The current snowflake is {Formatter.Timestamp(DiscordSentinals.DiscordEpoch.AddMilliseconds(unixTimestamp >> 22), TimestampFormat.LongDateTime)}.");
    }
}