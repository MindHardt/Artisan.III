using Artisan.III.Shared.Models.Catan;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Server.Services.Catan;

/// <summary>
/// Contains method used to retrieve appropriate catan chits (hex numbers).
/// </summary>
public interface ICatanChitsProvider : IService
{
    /// <summary>
    /// Gets ordered <see cref="IEnumerable{T}"/> with chits that corresponds to <paramref name="gameExtensions"/>.
    /// </summary>
    /// <param name="gameExtensions"></param>
    /// <returns></returns>
    public IEnumerable<HexChit> GetChits(CatanGameExtensions gameExtensions);
}