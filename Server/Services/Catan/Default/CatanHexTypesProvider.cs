using Artisan.III.Server.Core.Exceptions;
using Artisan.III.Shared.Models.Catan;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Server.Services.Catan.Default;

public class CatanHexTypesProvider : ICatanHexTypeProvider
{
    private static readonly HexType[] DefaultHexes =
    {
        /* 1 desert   */ HexType.Desert,
        /* 3 hills    */ HexType.Hills, HexType.Hills, HexType.Hills,
        /* 4 forests  */ HexType.Forest, HexType.Forest, HexType.Forest, HexType.Forest,
        /* 3 cliffs   */ HexType.Cliffs, HexType.Cliffs, HexType.Cliffs,
        /* 4 pastures */ HexType.Pasture, HexType.Pasture, HexType.Pasture, HexType.Pasture,
        /* 4 fields   */ HexType.Field, HexType.Field, HexType.Field, HexType.Field
    };

    private static readonly HexType[] ExpandedHexes =
    {
        /* +1 desert   */ HexType.Desert,
        /* +2 hills    */ HexType.Hills, HexType.Hills,
        /* +2 forests  */ HexType.Forest, HexType.Forest,
        /* +2 cliffs   */ HexType.Cliffs, HexType.Cliffs,
        /* +2 pastures */ HexType.Pasture, HexType.Pasture,
        /* +2 fields   */ HexType.Field, HexType.Field,
    };
    
    public IEnumerable<HexType> GetHexTypes(CatanGameExtensions gameExtensions)
    {
        NotAllowedException.ThrowIf(gameExtensions.HasFlag(CatanGameExtensions.Seafarers));

        return gameExtensions.HasFlag(CatanGameExtensions.Expanded)
            ? DefaultHexes.Concat(ExpandedHexes)
            : DefaultHexes;
    }
}