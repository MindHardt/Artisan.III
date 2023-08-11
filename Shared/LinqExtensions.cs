namespace Artisan.III.Shared;

/// <summary>
/// Contains several extensions for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class LinqExtensions
{
    /// <summary>
    /// Sorts the elements of a sequence randomly using <paramref name="randomizer"/>.
    /// </summary>
    /// <param name="source">A sequence of values to order.</param>
    /// <param name="randomizer">
    /// A function that produces random <see cref="IComparable"/>s.
    /// If not provided then <see cref="Random"/> is used.
    /// </param>
    /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <returns>An <see cref="IOrderedEnumerable{TElement}"/> whose elements are sorted randomly.</returns>
    public static IOrderedEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Func<IComparable>? randomizer = null)
    {
        randomizer ??= () => Random.Shared.Next();
        return source.OrderBy(_ => randomizer());
    }

    /// <summary>
    /// Sorts the elements of a sequence randomly using <paramref name="random"/>.
    /// </summary>
    /// <param name="source">A sequence of values to order.</param>
    /// <param name="random"></param>
    /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <returns>An <see cref="IOrderedEnumerable{TElement}"/> whose elements are sorted randomly.</returns>
    public static IOrderedEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random random)
    {
        return source.OrderBy(_ => random.Next());
    }
}