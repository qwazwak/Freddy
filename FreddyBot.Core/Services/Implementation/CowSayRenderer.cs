using System.Threading;
using System.Threading.Tasks;
using Cowsay.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace FreddyBot.Core.Services.Implementation;
public class CowSayRenderer
{
    private readonly ILogger<CowSayRenderer> logger;
    private readonly ICattleFarmer cattleFarmer;
    private ICow? defaultCow;
    private readonly IMemoryCache cowCache;
    public CowSayRenderer(ILogger<CowSayRenderer> logger, ICattleFarmer cattleFarmer, IMemoryCache cowCache)
    {
        this.logger = logger;
        this.cattleFarmer = cattleFarmer;
        this.cowCache = cowCache;
    }

    private ValueTask<ICow> GetCow(string? cow)
    {
        if (cow == null)
            return defaultCow != null ? new(defaultCow) : new(GetDefaultCow());

        return new(cowCache.GetOrCreate(cow, (entry) =>
        {
            logger.LogInformation("loading cow {cowName}", cow);
            return cattleFarmer.RearCowAsync(cow);
        })!);
    }

    private async Task<ICow> GetDefaultCow()
    {
        ICow newCow = await cattleFarmer.RearCowAsync("default");
        logger.LogTrace("Loaded default cow");
        return Interlocked.CompareExchange(ref defaultCow, newCow, null)!;
    }

    public ValueTask<string> Render(string cow, string phrase, string? eyes, string? cowTongue, int? maxCols, bool? isThought)
    {
        ValueTask<ICow> cowVT = GetCow(cow);
        if (cowVT.IsCompleted)
            return new(PostRender(cowVT.Result, phrase, eyes, cowTongue, maxCols, isThought));

        return new(cowVT.AsTask().ContinueWith(c => PostRender(c.Result, phrase, eyes, cowTongue, maxCols, isThought)));
    }

    private string PostRender(ICow cow, string phrase, string? eyes, string? cowTongue, int? maxCols, bool? isThought) => cow.Say(phrase, eyes ?? "oo", cowTongue ?? "  ", maxCols ?? 40, isThought ?? false);
}