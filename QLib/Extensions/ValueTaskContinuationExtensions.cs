using System;
using System.Threading.Tasks;

namespace QLib.Extensions;
public static class ValueTaskContinuationExtensions
{
    public static ValueTask<T2> ContinueAfterWith<T1, T2>(this ValueTask<T1> valueTask, Func<T1, T2> resultFactory)
    {
        if (valueTask.IsCompleted)
            return new(resultFactory(valueTask.Result));
        return new(valueTask.AsTask().ContinueAfterWith(resultFactory));
    }

    public static Task<T2> ContinueAfterWith<T1, T2>(this ValueTask<T1> valueTask, Func<T1, Task<T2>> resultFactory)
    {
        if (valueTask.IsCompleted)
            return resultFactory(valueTask.Result);
        return valueTask.AsTask().ContinueAfterWith(resultFactory);
    }
}
