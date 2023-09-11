using System;
using System.Threading.Tasks;
using FreddyBot.Core.Services.Implementation.Database;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Core.Services.Implementation;

public class BadPasswordCounter
{
    private readonly BadPasswordContext context;
    private DateTime LastFetchedAt { set => ExpiresAt = value + ExpireTime; }
    private readonly TimeSpan ExpireTime = TimeSpan.FromMilliseconds(5);
    private DateTime ExpiresAt;
    private int count;

    public BadPasswordCounter(BadPasswordContext context) => this.context = context;

    public bool TryGetCount(out int count)
    {
        if(this.count == -1)
        {
            count = -1;
            return false;
        }

        if(DateTime.Now >= ExpiresAt)
        {
            this.count = count = -1;
            return false;
        }

        count = this.count;
        return true;
    }
    public ValueTask<int> Count => TryGetCount(out int count) ? ValueTask.FromResult(count) : new(GetCount());
    private async Task<int> GetCount()
    {
        int newCount = await context.BadPasswords.CountAsync();
        LastFetchedAt = DateTime.Now;
        return count = newCount;
    }
}
