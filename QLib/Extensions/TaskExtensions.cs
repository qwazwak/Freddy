using System;
using System.Threading.Tasks;

namespace QLib.Extensions;

public static class TaskExtensions
{
    public static async Task<T> WithResult<T>(this Task task, T result)
    {
        await task.ConfigureAwait(false);
        return result;
    }

    public static async Task<T> WithResult<T>(this Task task, Func<T> resultFactory)
    {
        await task.ConfigureAwait(false);
        return resultFactory();
    }
}
