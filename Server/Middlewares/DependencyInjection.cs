namespace Artisan.III.Server.Middlewares;

/// <summary>
/// Contains extension methods for adding middlewares.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds <see cref="ErrorHandlingMiddleware"/> to the <paramref name="services"/>.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddErrorHandling(this IServiceCollection services) =>
        services.AddScoped<ErrorHandlingMiddleware>();

    /// <summary>
    /// Adds <see cref="ErrorHandlingMiddleware"/> to the middleware conveyor.
    /// This middleware catches <see cref="Exception"/>s and set response status codes
    /// appropriately.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app) =>
        app.UseMiddleware<ErrorHandlingMiddleware>();
}