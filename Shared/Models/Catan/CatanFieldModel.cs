using Artisan.III.Shared.Models.Catan.Buildings;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Shared.Models.Catan;

public record CatanFieldModel(CatanGameExtensions GameExtensions, HexModel[] Hexes, SettlementModel[] Settlements);