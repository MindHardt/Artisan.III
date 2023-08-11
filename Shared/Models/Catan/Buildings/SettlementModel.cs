using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Shared.Models.Catan.Buildings;

public record SettlementModel(SettlementKind Kind, PlayerColor Color, HexCoordinates Coordinates);