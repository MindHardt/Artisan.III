using System.Globalization;

namespace Artisan.III.Client;

public static class Extensions
{
    private static readonly CultureInfo DotSeparatorCulture = CultureInfo.GetCultureInfo("en");

    /// <summary>
    /// Formats <paramref name="number"/> in a way that is used by css (dot-separated).
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string ToCssString(this double number) => number.ToString(DotSeparatorCulture);
    
    /// <summary>
    /// Formats <paramref name="number"/> in a way that is used by css (dot-separated).
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string ToCssString(this float number) => number.ToString(DotSeparatorCulture);
}