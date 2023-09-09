using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal class ShortScopeProvider : IShortScopeProvider
{
    private readonly IServiceProvider provider;
    public ShortScopeProvider(IServiceProvider provider) => this.provider = provider;

    public async Task RunAsync<T>(Func<T, Task> factory) where T : class
    {
        await using AsyncServiceScope scope = provider.CreateAsyncScope();
        T service = scope.ServiceProvider.GetRequiredService<T>();
        await factory.Invoke(service);
    }
    public void Run<T>(Action<T> factory) where T : class
    {
        using IServiceScope scope = provider.CreateScope();
        T service = scope.ServiceProvider.GetRequiredService<T>();
        factory.Invoke(service);
    }
}

internal class ShortScopeProvider<T> : IShortScopeProvider<T> where T : class
{
    private readonly IShortScopeProvider provider;
    public ShortScopeProvider(IShortScopeProvider provider) => this.provider = provider;

    public Task RunAsync(Func<T, Task> factory) => provider.RunAsync<T>(factory);
    public void Run(Action<T> factory) => provider.Run<T>(factory);
}