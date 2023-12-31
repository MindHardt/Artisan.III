using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Tests;

public class HexCoordinatesTest
{
    [Fact]
    public void TestNeighbourCheck()
    {
        HexCoordinates center = "H6";
        
        HexCoordinates neighbourHex1 = "H4";
        HexCoordinates neighbourHex2 = "F5";
        HexCoordinates notNeighbourHex = "F9";

        HexCoordinates neighbourCrossroad = "G6";
        HexCoordinates notNeighbourCrossroad = "E6";
        
        Assert.True(center.IsNeighborTo(neighbourHex1));
        Assert.True(center.IsNeighborTo(neighbourHex2));
        Assert.False(center.IsNeighborTo(notNeighbourHex));
        
        Assert.True(center.IsNeighborTo(neighbourCrossroad));
        Assert.False(center.IsNeighborTo(notNeighbourCrossroad));
    }

    [Fact]
    public void TestNeighbourCalculation()
    {
        HexCoordinates centerHex = "F7";

        HexCoordinates[] centerHexNeighboursExpected = { "E6", "E7", "E8", "G6", "G7", "G8" };
        HexCoordinates[] centerHexNeighboursCalculated = centerHex.GetNeighbors().ToArray();
        
        Assert.Equal(Sort(centerHexNeighboursExpected), Sort(centerHexNeighboursCalculated));
        Assert.All(centerHexNeighboursCalculated, 
            x => Assert.Equal(HexCoordinateKind.Crossroad, x.Kind));
        Assert.All(centerHexNeighboursCalculated,
            x => Assert.True(x.IsNeighborTo(centerHex)));

        HexCoordinates centerCrossroad = "E6";

        HexCoordinates[] centerCrossroadNeighboursExpected = { "D6", "F5", "F7" };
        HexCoordinates[] centerCrossroadNeighboursCalculated = centerCrossroad.GetNeighbors().ToArray();
        
        Assert.Equal(Sort(centerCrossroadNeighboursExpected), Sort(centerCrossroadNeighboursCalculated));
        Assert.All(centerCrossroadNeighboursCalculated, 
            x => Assert.Equal(HexCoordinateKind.Hex, x.Kind));
        Assert.All(centerCrossroadNeighboursCalculated,
            x => Assert.True(x.IsNeighborTo(centerCrossroad)));
    }

    [Fact]
    public void TestBorders()
    {
        HexCoordinates topBorder = "F1";
        HexCoordinates bottomBorder = "F99";
        HexCoordinates leftBorder = "A5";
        HexCoordinates rightBorder = "Z5";
        
        Assert.True(topBorder.IsTopBorder);
        Assert.True(bottomBorder.IsBottomBorder);
        Assert.True(leftBorder.IsLeftBorder);
        Assert.True(rightBorder.IsRightBorder);
    }

    private static HexCoordinates[] Sort(IEnumerable<HexCoordinates> original) 
        => original.OrderBy(x => x.ToString()).ToArray();
}