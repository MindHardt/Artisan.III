namespace Artisan.III.Shared.Models.Catan.Buildings;

/// <summary>
/// The type of settlement.
/// </summary>
public enum SettlementKind : byte
{
    /// <summary>
    /// A small village that produces 1 resource.
    /// </summary>
    Village = 1,
    /// <summary>
    /// A big town that produces 2 resources.
    /// </summary>
    Town = 2
}