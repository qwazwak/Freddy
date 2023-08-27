using System;
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
    private readonly Task<ICow> defaultCowTask;

    private readonly IMemoryCache cowCache;
    public CowSayRenderer(ILogger<CowSayRenderer> logger, ICattleFarmer cattleFarmer, IMemoryCache cowCache)
    {
        this.logger = logger;
        this.cattleFarmer = cattleFarmer;
        this.cowCache = cowCache;
        //cowCache.CreateEntry("default").Value = cattleFarmer.RearCowAsync("default");
        defaultCowTask = cattleFarmer.RearCowAsync("default");
    }

    private ValueTask<ICow> GetCow(string? cow)
    {
        if (cow == null)
            return defaultCowTask.IsCompleted ? new(defaultCowTask.Result) : new(defaultCowTask);

        return new(cowCache.GetOrCreate(cow, (entry) =>
        {
            logger.LogInformation("loading cow {cowName}", cow);
            return cattleFarmer.RearCowAsync(cow);
        })!);
    }

    public ValueTask<string> Render(string cow, string phrase, string? eyes, string? cowTongue, int? maxCols, bool? isThought)
    {
        ValueTask<ICow> cowVT = GetCow(cow);

        return cowVT.IsCompleted ? new(finalRender(cowVT.Result)) : new(cowVT.AsTask().ContinueWith(c => finalRender(c.Result)));
        string finalRender(ICow cow) => cow.Say(phrase, eyes ?? "oo", cowTongue ?? "  ", maxCols ?? 40, isThought ?? false);
    }
}