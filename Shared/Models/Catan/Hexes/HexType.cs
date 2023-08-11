namespace Artisan.III.Shared.Models.Catan.Hexes;

public enum HexType
{
    /// <summary>
    /// The desert with no resources.
    /// </summary>
    Desert,
    
    /// <summary>
    /// The sea with no resources.
    /// </summary>
    Sea,
    
    /// <summary>
    /// Produces <see cref="ResourceType.Clay"/>.
    /// </summary>
    Hills,
    
    /// <summary>
    /// Produces <see cref="ResourceType.Lumber"/>.
    /// </summary>
    Forest,
    
    /// <summary>
    /// Produces <see cref="ResourceType.Ore"/>.
    /// </summary>
    Cliffs,
    
    /// <summary>
    /// Produces <see cref="ResourceType.Sheep"/>.
    /// </summary>
    Pasture,
    
    /// <summary>
    /// Produces <see cref="ResourceType.Wheat"/>.
    /// </summary>
    Field
}