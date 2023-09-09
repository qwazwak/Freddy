using Microsoft.Extensions.Hosting;

namespace DSharpPlus.BetterHosting.Hosting;

public static class BetterHostExtensions
{
    public static IHostBuilder WithBetterHosting(this IHostBuilder builder)
    {
        if (builder is BetterHostBuilder)
            return builder;
        return new BetterHostBuilder(builder);
    }
}
