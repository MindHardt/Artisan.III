using Artisan.III.Shared;
using Artisan.III.Shared.Models.Catan;
using Artisan.III.Shared.Models.Catan.Hexes;
using Microsoft.AspNetCore.Components;

namespace Artisan.III.Client.Components.Catan;

public partial class CatanFieldComponent
{
    private float _rowCount;
    private float _columnCount;
    private float _hexWidth;
    private float _hexHeight;
    
    private float _settlementSize;
    
    [Parameter, EditorRequired]
    public CatanFieldModel Model { get; set; } = null!;
    [Inject]
    public ILogger<CatanFieldComponent> Logger { get; set; } = null!;

    protected override void OnParametersSet()
    {
        _rowCount = Model.Hexes.Select(x => x.Coordinates.Row).Distinct().Count();
        _columnCount = Model.Hexes.Select(x => x.Coordinates.Column).Distinct().Count();
        _hexWidth = 200f / (_rowCount + 1);
        _hexHeight = 100f / (_columnCount * 1.5f + 0.5f) * 2f;
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
        float left = (0.5f + (coords.ColumnNumber - 1) / 2 * 0.75f) * _hexWidth;
        float top = coords.Row * 0.5f * _hexHeight;
        var pos = new Position(left, top);
        Logger.LogInformation("Position of hex {Coords} is {Pos}", coords, pos);
        return pos;
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
        int effectiveColumn = coords.ColumnNumber >> 1;
        float columnOffset = effectiveColumn.IsEven() ? 0.5f : 0f;
        
        float left = effectiveColumn * _hexWidth + columnOffset;
        float top = (coords.Row - 1) * _hexHeight / 2;
        var pos = new Position(left, top);
        Logger.LogInformation("Position of crossroad {Coords} is {Pos}", coords, pos);
        return pos;
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