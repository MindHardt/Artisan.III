using Artisan.III.Shared.Models.Catan;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Client.Components.Catan;

public record CatanFieldDisplayHelper(int RowCount, int ColumnCount)
{
    private readonly float _hexHeightPercent = 200f / (RowCount + 1);
    private readonly float _hexWidthPercent = 100f / (ColumnCount * 1.5f + 0.5f) * 2f;
        
    private readonly float _settlementTokenSidePercent = 200f / (RowCount + 1) / 3;

    public CatanFieldDisplayHelper(HexModel[] hexes) : this(GetRowCount(hexes), GetColumnCount(hexes))
    { }

    public CatanFieldDisplayHelper(CatanFieldModel field) : this(field.Hexes)
    { }

    public string GetPositionStyle(HexCoordinates coords) => coords.Kind switch
    {
        HexCoordinateKind.Hex => GetHexStyle(coords).ToString(),
        HexCoordinateKind.Crossroad => GetCrossroadStyle(coords).ToString(),
        _ => throw new ArgumentOutOfRangeException(nameof(coords.Kind))
    };

    private Style GetHexStyle(HexCoordinates coords)
    {
        float left = ((coords.ColumnNumber >> 1) - 1f) / (ColumnCount + 0.40f);
        float top = (coords.Row - 1) / (RowCount + 1f) * 100;

        return new Style(left, top, _hexWidthPercent, _hexHeightPercent);
    }

    private Style GetCrossroadStyle(HexCoordinates coords)
    {

    }

    private static int GetRowCount(IEnumerable<HexModel> hexes) => hexes
        .Select(x => x.Coordinates.Row)
        .Distinct()
        .Count();
    private static int GetColumnCount(IEnumerable<HexModel> hexes) => hexes
        .Select(x => x.Coordinates.Column)
        .Distinct()
        .Count();

    private readonly record struct Style(float Left, float Top, float Width, float Height)
    {
        public override string ToString() =>
            $"left: {Left.ToCssString()}%;" +
            $"top: {Top.ToCssString()}%;" +
            $"width: {Width.ToCssString()}%;" +
            $"height: {Height.ToCssString()}%";
    }
}