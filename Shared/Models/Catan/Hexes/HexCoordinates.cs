using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Artisan.III.Shared.Models.Catan.Hexes;

/// <summary>
/// Represents hexagonal coordinates in a custom coordinate system.
/// </summary>
/// <param name="Column">The uppercase latin letter representing column in a hexagonal field.</param>
/// <param name="Row">The number of row.</param>
public readonly record struct HexCoordinates(
    [Range(HexCoordinates.LeftBorder, HexCoordinates.RightBorder)] char Column, 
    [Range(HexCoordinates.TopBorder, HexCoordinates.BottomBorder)] byte Row)
{
    /// <summary>
    /// Gets the number of <see cref="HexCoordinates.Column"/> (starting from 1).
    /// </summary>
    public byte ColumnNumber => (byte)(Column - 'A' + 1);

    /// <summary>
    /// Gets the <see cref="HexCoordinateKind"/> of this <see cref="HexCoordinates"/>.
    /// </summary>
    public HexCoordinateKind Kind => ColumnNumber % 2 == 0
        ? HexCoordinateKind.Hex
        : HexCoordinateKind.Crossroad;
    
    #region Borders

    /// <summary>
    /// The top row number.
    /// </summary>
    public const int TopBorder = 1;
    /// <summary>
    /// Defines whether this <see cref="HexCoordinates"/> are at top border, i.e. nothing can be above it.
    /// </summary>
    public bool IsTopBorder => Row is TopBorder;

    /// <summary>
    /// The bottom row number.
    /// </summary>
    public const int BottomBorder = 99;
    /// <summary>
    /// Defines whether this <see cref="HexCoordinates"/> are at bottom border, i.e. nothing can be below it.
    /// </summary>
    public bool IsBottomBorder => Row is BottomBorder;
    
    /// <summary>
    /// The top row number.
    /// </summary>
    public const char LeftBorder = 'A';
    /// <summary>
    /// Defines whether this <see cref="HexCoordinates"/> are at left border, i.e. nothing can be left to it.
    /// </summary>
    public bool IsLeftBorder => Column is LeftBorder;

    /// <summary>
    /// The bottom row number.
    /// </summary>
    public const char RightBorder = 'Z';
    /// <summary>
    /// Defines whether this <see cref="HexCoordinates"/> are at right border, i.e. nothing can be right to it.
    /// </summary>
    public bool IsRightBorder => Column is RightBorder;

    #endregion

    #region Conversions

    /// <summary>
    /// The regular expression that string representations of <see cref="HexCoordinates"/> must match.
    /// </summary>
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string HexCoordinateRegexString = "[a-zA-Z][0-9]{1,2}";

    /// <summary>
    /// Creates a new <see cref="HexCoordinates"/> from <paramref name="value"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static HexCoordinates FromString([RegularExpression(HexCoordinateRegexString)] string value)
        => new(char.ToUpper(value[0]), byte.Parse(value[1..]));
    
    public static implicit operator HexCoordinates(string value) 
        => FromString(value);

    /// <summary>
    /// Returns the string representation of this <see cref="HexCoordinates"/>.
    /// Returned string is expected to be parsable back using <see cref="FromString"/>.
    /// </summary>
    /// <returns></returns>
    public override string ToString() 
        => $"{Column}{Row}";

    #endregion

    #region Neighbours

    /// <summary>
    /// Gets neighbours of different <see cref="Kind"/>.
    /// For <see cref="HexCoordinateKind.Hex"/> gets all six crossroads around it.
    /// For <see cref="HexCoordinateKind.Crossroad"/> gets up to three hexes around it.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public IEnumerable<HexCoordinates> GetNeighbours() => Kind switch
    {
        HexCoordinateKind.Hex => GetNeighboursHex(),
        HexCoordinateKind.Crossroad => GetNeighboursCrossroad(),
        _ => throw new ArgumentOutOfRangeException()
    };

    private IEnumerable<HexCoordinates> GetNeighboursHex()
    {
        yield return this with { Row = (byte)(Row - 1), Column = (char)(Column - 1) };
        yield return this with { Row = (byte)(Row - 1), Column = (char)(Column + 1) };
        yield return this with { Column = (char)(Column + 1) };
        yield return this with { Column = (char)(Column - 1) };
        yield return this with { Row = (byte)(Row + 1), Column = (char)(Column - 1) };
        yield return this with { Row = (byte)(Row + 1), Column = (char)(Column + 1) };
    }

    private IEnumerable<HexCoordinates> GetNeighboursCrossroad()
    {
        bool isLeftPosition = (Row + ColumnNumber / 2).IsEven();
        if (IsTopBorder is false) // north
        {
            yield return isLeftPosition
                ? this with { Row = (byte)(Row - 1), Column = (char)(Column + 1) }
                : this with { Row = (byte)(Row - 1), Column = (char)(Column - 1) };
        }
        if (IsBottomBorder is false) // south
        {
            yield return isLeftPosition
                ? this with { Row = (byte)(Row + 1), Column = (char)(Column + 1) }
                : this with { Row = (byte)(Row + 1), Column = (char)(Column - 1) };
        }
        if (IsLeftBorder is false && isLeftPosition) // west
        {
            yield return this with { Column = (char)(Column - 1) };
        }
        if (IsRightBorder is false && isLeftPosition is false) // east
        {
            yield return this with { Column = (char)(Column + 1) };
        }
    }

    #endregion
    
    /// <summary>
    /// Determines whether two <see cref="HexCoordinates"/> are considered neighbouring.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool IsNeighbourTo(HexCoordinates other) =>
        Math.Abs(ColumnNumber - other.ColumnNumber) <= 2 &&
        Math.Abs(Row - other.Row) <= 2;
}