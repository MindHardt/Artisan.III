namespace Artisan.III.Shared.Models.Catan.Hexes;

public static class HexExtensions
{
    /// <summary>
    /// Determines whether <paramref name="hexType"/> can produce resources.
    /// </summary>
    /// <param name="hexType"></param>
    /// <returns></returns>
    public static bool RequiresChit(this HexType hexType)
        => hexType is not HexType.Desert and not HexType.Sea;
}