using System;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services;

internal interface IShortScopeProvider
{
    public Task RunAsync<T>(Func<T, Task> factory) where T : class;
    public void Run<T>(Action<T> factory) where T : class;
}

internal interface IShortScopeProvider<T> where T : class
{
    public Task RunAsync(Func<T, Task> factory);
    public void Run(Action<T> factory);
}