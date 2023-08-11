namespace Artisan.III.Server.Fakers;

public static class DependencyInjection
{
    /// <summary>
    /// Adds all implementations of <see cref="IFaker{T}"/> interface to <paramref name="services"/>.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddFakers(this IServiceCollection services)
    {
        services.Scan(scan =>
        {
            scan.FromAssembliesOf(typeof(DependencyInjection))
                .AddClasses(c => c.AssignableTo(typeof(IFaker<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        return services;
    }
}
