using System;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;

namespace DiscordExtensions;

public static class DiscordChannelExtensions
{

    public static async Task<DiscordMessage?> GetMessageOrNullAsync(this DiscordChannel channel, ulong id, bool skipCache = false)
    {
        try
        {
            return await channel.GetMessageAsync(id, skipCache);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }
}
