#define CountByIfChain
using System.Runtime.CompilerServices;

namespace QLib.Extensions;

public static partial class DigitCountExtensions
{
#if CountByIfChain
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Digits(this int n)
    {
        if (n >= 0)
        {
            if (n < 10) return 1;
            if (n < 100) return 2;
            if (n < 1000) return 3;
            if (n < 10000) return 4;
            if (n < 100000) return 5;
            if (n < 1000000) return 6;
            if (n < 10000000) return 7;
            if (n < 100000000) return 8;
            if (n < 1000000000) return 9;
            return 10;
        }
        else
        {
            if (n > -10) return 2;
            if (n > -100) return 3;
            if (n > -1000) return 4;
            if (n > -10000) return 5;
            if (n > -100000) return 6;
            if (n > -1000000) return 7;
            if (n > -10000000) return 8;
            if (n > -100000000) return 9;
            if (n > -1000000000) return 10;
            return 11;
        }
    }
#endif

#if CountByLog10
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Digits(this int n)
    {
        if(n > 0)
            return 1 + (int)Math.Log10(Math.Abs((double)n));
        else if (n != 0)
            return 2 + (int)Math.Log10(Math.Abs((double)n));
        else
            return 1;
    }
#endif
}
