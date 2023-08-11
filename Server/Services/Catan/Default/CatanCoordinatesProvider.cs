using Artisan.III.Server.Core.Exceptions;
using Artisan.III.Shared.Models.Catan;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Server.Services.Catan.Default;

public class CatanCoordinatesProvider : ICatanCoordinatesProvider
{
    private static readonly HexCoordinates[] DefaultCoordinates =
    {
        "F3", "H4", "J5", "J7", "J9", "H10", "F11", "D10", "B9", "B7", "B5", "D4", "F5", "H6", "H8", "F9", "D8", "D6", "F7"
    };

    private static readonly HexCoordinates[] ExpandedCoordinates =
    {
        "H2", "J3", "L4", "N5", "N7", "N9", "L10", "J11", "H12", "F11", "D10", "B9", "B7", "B5", "D4", "F3", "H4", "J5", "L6", "L8", "J9", "H10", "F9", "D8", "D6", "F5", "H6" , "J7", "H8", "F7" 
    };
    
    public IEnumerable<HexCoordinates> GetCoordinates(CatanGameExtensions gameExtensions)
    {
        NotAllowedException.ThrowIf(gameExtensions.HasFlag(CatanGameExtensions.Seafarers));

        return gameExtensions.HasFlag(CatanGameExtensions.Expanded)
            ? ExpandedCoordinates
            : DefaultCoordinates;
    }
}