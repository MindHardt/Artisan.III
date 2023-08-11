namespace Artisan.III.Server.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services) => services.Scan(scan =>
    {
        scan.FromAssembliesOf(typeof(DependencyInjection))
            .AddClasses(c => c.AssignableTo<IService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime();
    });
}