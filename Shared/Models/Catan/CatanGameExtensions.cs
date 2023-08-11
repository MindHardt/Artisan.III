using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Shared.Models.Catan;

[Flags]
public enum CatanGameExtensions
{
    /// <summary>
    /// The default field for 3-4 players with 19 hexes and one <see cref="HexType.Desert"/>.
    /// </summary>
    None = 0,
    /// <summary>
    /// A bigger field for 5-6 players. It is compatible with other extensions.
    /// </summary>
    Expanded = 1<<0,
    /// <summary>
    /// Seafarers expansion that adds seas and expands the field.
    /// </summary>
    Seafarers = 1<<1
}