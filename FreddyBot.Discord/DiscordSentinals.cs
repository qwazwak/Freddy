using System;

namespace FreddyBot.Discord;

public static class DiscordSentinals
{
    /// <summary>
    /// Discord snowflakes use 2015 (the launch date) as it's epoch for timestamps.
    /// </summary>
    public static readonly DateTimeOffset DiscordEpoch = new(2015, 1, 1, 0, 0, 0, TimeSpan.Zero);
}
