using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace QLib.Extensions;

public static class TimeSpanEnumerableExtensions
{
    public static TimeSpan Average(this IEnumerable<TimeSpan> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (source.TryGetNonEnumeratedCount(out int fastCount))
            return source.Sum() / fastCount;

        using IEnumerator<TimeSpan> e = source.GetEnumerator();
        if (!e.MoveNext())
            throw new ArgumentNullException(nameof(source), "source cannot be empty");

        TimeSpan sum = e.Current;
        long count = 1;

        while (e.MoveNext())
        {
            checked { sum += e.Current; }
            count++;
        }

        return sum / count;
    }

    public static TimeSpan Sum(this IEnumerable<TimeSpan> source) => source.TryGetSpan(out ReadOnlySpan<TimeSpan> span) ? Sum(span) : SumEnumerable(source);
    private static TimeSpan SumEnumerable(this IEnumerable<TimeSpan> source)
    {
        TimeSpan sum = TimeSpan.Zero;
        foreach (TimeSpan value in source)
            checked { sum += value; }
        return sum;
    }

    private static TimeSpan Sum(ReadOnlySpan<TimeSpan> span)
    {
        TimeSpan sum = TimeSpan.Zero;
        foreach (TimeSpan value in span)
            checked { sum += value; }

        return sum;
    }

    /// <summary>Validates that source is not null and then tries to extract a span from the source.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)] // fast type checks that don't add a lot of overhead
    private static bool TryGetSpan<TSource>(this IEnumerable<TSource> source, out ReadOnlySpan<TSource> span)
        // This constraint isn't required, but the overheads involved here can be more substantial when TSource
        // is a reference type and generic implementations are shared.  So for now we're protecting ourselves
        // and forcing a conscious choice to remove this in the future, at which point it should be paired with
        // sufficient performance testing.
        where TSource : struct
    {
        ArgumentNullException.ThrowIfNull(source);

        // Use `GetType() == typeof(...)` rather than `is` to avoid cast helpers.  This is measurably cheaper
        // but does mean we could end up missing some rare cases where we could get a span but don't (e.g. a uint[]
        // masquerading as an int[]).  That's an acceptable tradeoff.  The Unsafe usage is only after we've
        // validated the exact type; this could be changed to a cast in the future if the JIT starts to recognize it.
        // We only pay the comparison/branching costs here for super common types we expect to be used frequently
        // with LINQ methods.

        bool result = true;
        if (source.GetType() == typeof(TSource[]))
        {
            span = Unsafe.As<TSource[]>(source);
        }
        else if (source.GetType() == typeof(List<TSource>))
        {
            span = CollectionsMarshal.AsSpan(Unsafe.As<List<TSource>>(source));
        }
        else
        {
            span = default;
            result = false;
        }

        return result;
    }
}
