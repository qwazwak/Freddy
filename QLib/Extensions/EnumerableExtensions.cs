using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace QLib.Extensions;

public static class EnumerableExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> enumerable) => enumerable.Where(i => i != null).Cast<T>();
}
