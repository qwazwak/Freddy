using System;
using System.Collections.Generic;
using System.Threading;
using Nito.AsyncEx;
using System.Runtime.CompilerServices;

namespace QLib.Extensions;

public static class AsyncCollectionExtensions
{
    /// <summary>
    /// Provides a (synchronous) consuming enumerable for items in the producer/consumer collection.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to abort the synchronous enumeration.</param>
    public static async IAsyncEnumerable<T> GetConsumingAsyncEnumerable<T>(this AsyncCollection<T> source, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        while (true)
        {
            T item;
            try
            {
                item = await source.TakeAsync(cancellationToken);
            }
            catch (InvalidOperationException)
            {
                yield break;
            }

            yield return item;
        }
    }
}
