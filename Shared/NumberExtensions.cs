using System.Numerics;

namespace Artisan.III.Shared;

public static class NumberExtensions
{
    /// <summary>
    /// Determines whether <paramref name="number"/> is even.
    /// </summary>
    /// <param name="number"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>
    /// <see langword="true"/> if <paramref name="number"/> is even, otherwise <see langword="false"/>.
    /// </returns>
    public static bool IsEven<T>(this T number) where T : IBinaryNumber<T>
        => (number & T.One) == T.Zero;
    
    /// <summary>
    /// Determines whether <paramref name="number"/> is odd.
    /// </summary>
    /// <param name="number"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>
    /// <see langword="true"/> if <paramref name="number"/> is odd, otherwise <see langword="false"/>.
    /// </returns>
    public static bool IsOdd<T>(this T number) where T : IBinaryNumber<T>
        => (number & T.One) != T.Zero;

}