using Artisan.III.Server.Core.Exceptions;
using Artisan.III.Shared.Models.Catan;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Server.Services.Catan.Default;

public class CatanChitsProvider : ICatanChitsProvider
{
    private static readonly HexChit[] DefaultChits =
    {
        5, 2, 6, 3, 8, 10, 9, 12, 11, 4, 8, 10, 9, 4, 5, 6, 3, 11
    };

    private static readonly HexChit[] ExpandedChits =
    {
        2, 5, 4, 6, 3, 9, 8, 11, 11, 10, 6, 3, 8, 4, 8, 10, 11, 12, 10, 5, 4, 9, 5, 9, 12, 3, 2, 6
    };
    
    public IEnumerable<HexChit> GetChits(CatanGameExtensions gameExtensions)
    {
        NotAllowedException.ThrowIf(gameExtensions.HasFlag(CatanGameExtensions.Seafarers));

        return gameExtensions.HasFlag(CatanGameExtensions.Expanded)
            ? ExpandedChits
            : DefaultChits;
    }
}