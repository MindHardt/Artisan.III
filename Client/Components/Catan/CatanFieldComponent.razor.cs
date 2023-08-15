using Artisan.III.Shared;
using Artisan.III.Shared.Models.Catan;
using Artisan.III.Shared.Models.Catan.Hexes;
using Microsoft.AspNetCore.Components;

namespace Artisan.III.Client.Components.Catan;

public partial class CatanFieldComponent
{
    private byte _topRow;
    private float _rowCount;
    private float _columnCount;
    private float _hexWidth;
    private float _hexHeight;
    
    private float _settlementSize;
    
    [Parameter, EditorRequired]
    public CatanFieldModel Model { get; set; } = null!;

    protected override void OnParametersSet()
    {
        _topRow = Model.Hexes.Min(x => x.Coordinates.Row);
        _rowCount = Model.Hexes.Select(x => x.Coordinates.Row).Distinct().Count();
        _columnCount = Model.Hexes.Select(x => x.Coordinates.Column).Distinct().Count();
        _hexWidth = 100f / (0.25f + _columnCount * 0.75f);
        _hexHeight = 100f / (0.5f + _rowCount * 0.5f);
        _settlementSize = _hexWidth / 3;
    }

    private Style GetPositionStyle(HexCoordinates coords) => coords.Kind switch
    {
        HexCoordinateKind.Hex => GetHexStyle(coords),
        HexCoordinateKind.Crossroad => GetCrossroadStyle(coords),
        _ => throw new ArgumentOutOfRangeException(nameof(coords))
    };

    private Style GetHexStyle(HexCoordinates coords)
    {
        Position pos = GetHexPosition(coords);
        float left = pos.Left - _hexWidth / 2;
        float top = pos.Top - _hexHeight / 2;
        return new Style(left, top, _hexWidth, _hexHeight);
    }

    private Position GetHexPosition(HexCoordinates coords)
    {
        float left = (0.25f + (coords.ColumnNumber - 1) * 0.75f) / 2 * _hexWidth;
        float top = (coords.Row - _topRow + 1) * 0.5f * _hexHeight;
        return new Position(left, top);
    }

    private Style GetCrossroadStyle(HexCoordinates coords)
    {
        Position pos = GetCrossRoadPosition(coords);
        float left = pos.Left - _settlementSize / 2;
        float top = pos.Top - _settlementSize / 2;
        return new Style(left, top, _settlementSize, _settlementSize);
    }

    private Position GetCrossRoadPosition(HexCoordinates coords)
    {
        int effectiveColumn = (coords.ColumnNumber) >> 1;
        float columnOffset = (effectiveColumn + coords.Row).IsEven() ? 0.25f : 0f;
        
        float left = (effectiveColumn * 0.75f + columnOffset) * _hexWidth;
        float top = (coords.Row - _topRow + 1) * _hexHeight / 2;
        return new Position(left, top);
    }

    #region Intermediate Structs

    private readonly record struct Style(float Left, float Top, float Width, float Height)
    {
        public override string ToString() =>
            $"left: {Left.ToCssString()}%;" +
            $"top: {Top.ToCssString()}%;" +
            $"width: {Width.ToCssString()}%;" +
            $"height: {Height.ToCssString()}%;";
    }

    private readonly record struct Position(float Left, float Top);

    #endregion
}