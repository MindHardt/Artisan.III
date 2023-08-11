using System.ComponentModel.DataAnnotations;

namespace Artisan.III.Shared.Models.Catan.Hexes;

/// <summary>
/// Represents catan hex chit, the number that defines which dice throws trigger resources production.
/// </summary>
/// <param name="Number"></param>
public readonly record struct HexChit([Range(2, 12)] byte Number)
{
    /// <summary>
    /// Gets the prestige of this <see cref="HexChit"/>.
    /// Prestige is a number that represents how often,
    /// in average, this chit will be triggered.
    /// </summary>
    [Range(1, 5)]
    public int Prestige 
        => 6 - Math.Abs(Number - 7);

    /// <summary>
    /// Creates a new <see cref="HexChit"/> from <paramref name="number"/>.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static HexChit FromNumber(byte number) 
        => new(number);
    
    public static implicit operator HexChit(byte number) 
        => FromNumber(number);
    
    public static implicit operator byte(HexChit chit) 
        => chit.Number;

    public override string ToString() => Number.ToString();
}