using Artisan.III.Shared.Models.Catan;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Server.Services.Catan;

/// <summary>
/// Contains method used to retrieve appropriate catan hex coordinates.
/// </summary>
public interface ICatanCoordinatesProvider : IService
{
    /// <summary>
    /// Gets ordered <see cref="IEnumerable{T}"/> with coordinates that corresponds to <paramref name="gameExtensions"/>.
    /// </summary>
    /// <param name="gameExtensions"></param>
    /// <returns></returns>
    public IEnumerable<HexCoordinates> GetCoordinates(CatanGameExtensions gameExtensions);
}