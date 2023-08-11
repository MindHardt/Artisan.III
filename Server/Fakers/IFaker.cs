namespace Artisan.III.Server.Fakers;

/// <summary>
/// Exposes method for creating possibly seeded random data of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IFaker<out T>
{
    /// <summary>
    /// Creates fake <typeparamref name="T"/> using <paramref name="seed"/> as randomizer seed
    /// And passing <paramref name="args"/> as additional arguments.
    /// </summary>
    /// <param name="seed"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public T Fake(object? seed = null, params object?[] args);
}