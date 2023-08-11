using Artisan.III.Server.Services.Catan;
using Artisan.III.Shared;
using Artisan.III.Shared.Models.Catan;
using Artisan.III.Shared.Models.Catan.Buildings;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Server.Fakers.Catan;

public class CatanFieldFaker : IFaker<CatanFieldModel>
{
    private readonly ICatanChitsProvider _chitsProvider;
    private readonly ICatanCoordinatesProvider _coordinatesProvider;
    private readonly ICatanHexTypeProvider _hexTypeProvider;

    public CatanFieldFaker(
        ICatanChitsProvider chitsProvider, 
        ICatanCoordinatesProvider coordinatesProvider, 
        ICatanHexTypeProvider hexTypeProvider)
    {
        _chitsProvider = chitsProvider;
        _coordinatesProvider = coordinatesProvider;
        _hexTypeProvider = hexTypeProvider;
    }

    public CatanFieldModel Fake(object? seed = null, params object?[] args)
    {
        CatanGameExtensions extensions = args.ElementAtOrDefault(0) as CatanGameExtensions? ?? CatanGameExtensions.None;
        
        var chits = GetChitsQueue(extensions);
        var coords = GetCoordinatesQueue(extensions);
        
        var randomSeed = seed?.GetHashCode() ?? Random.Shared.Next();
        var randomizer = new Random(randomSeed);

        var hexModels = _hexTypeProvider.GetHexTypes(extensions)
            .Shuffle(() => randomizer.Next())
            .Select(x => new HexModel(
                x, 
                x.RequiresChit() ? chits.Dequeue() : null,  
                coords.Dequeue()))
            .ToArray();
        var buildings = GetBuildings(hexModels, randomizer);

        return new CatanFieldModel(extensions, hexModels, buildings);
    }

    private Queue<HexChit> GetChitsQueue(CatanGameExtensions gameExtensions) 
        => new(_chitsProvider.GetChits(gameExtensions));

    private Queue<HexCoordinates> GetCoordinatesQueue(CatanGameExtensions gameExtensions)
        => new(_coordinatesProvider.GetCoordinates(gameExtensions));

    private SettlementModel[] GetBuildings(IEnumerable<HexModel> hexes, Random random) => hexes
        .Select(x => x.Coordinates.GetNeighbors())
        .SelectMany(x => x)
        .Distinct()
        .Shuffle(random)
        .Take(6)
        .Select(x => new SettlementModel(
            (SettlementKind)random.Next(1, 3),
            (PlayerColor)random.Next(6),
            x))
        .ToArray();
}