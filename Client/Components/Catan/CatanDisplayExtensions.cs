using Artisan.III.Shared.Models.Catan;

namespace Artisan.III.Client.Components.Catan;

public static class CatanDisplayExtensions
{
    /// <summary>
    /// Formats this <see cref="PlayerColor"/> to a <see langword="string"/> containing
    /// css filter property. The base color is expected to be #FF9933.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static string ToCssFilter(this PlayerColor color)
        => $"filter: " +
           $"hue-rotate({GetHueRotateDegrees(color)}deg) " +
           $"saturate({GetSaturatePercent(color)}%);";
    
    private static int GetHueRotateDegrees(PlayerColor color) => color switch
    {
        PlayerColor.Green => 90,
        PlayerColor.Blue => 180,
        PlayerColor.Pink => 270,
        _ => 0
    };
    private static int GetSaturatePercent(PlayerColor color) => color switch
    {
        PlayerColor.Red => 1000,
        PlayerColor.Gray => 0,
        _ => 100
    };
}