using System;
using System.Threading.Tasks;

namespace QLib.Extensions;

public static class TaskContinuationExtensions
{
    public static async Task<T2> ContinueAfterWith<T1, T2>(this Task<T1> task, Func<T1, T2> resultFactory)
    {
        T1 inner = await task.ConfigureAwait(false);
        return resultFactory(inner);
    }

    public static async Task<T2> ContinueAfterWith<T1, T2>(this Task<T1> task, Func<T1, Task<T2>> resultFactory)
    {
        T1 inner = await task.ConfigureAwait(false);
        return await resultFactory(inner).ConfigureAwait(false);
    }

    public static async Task<T2> ContinueAfterWith<T1, T2>(this Task<T1> task, Func<T1, ValueTask<T2>> resultFactory) => await resultFactory(await task);
}
