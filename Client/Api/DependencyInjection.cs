using System.Text.Json;
using System.Text.Json.Serialization;
using Artisan.III.Shared.JsonConverters;
using Refit;

namespace Artisan.III.Client.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddDebugApi(this IServiceCollection services, string baseAddress)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        jsonOptions.Converters.Add(new HexCoordinatesJsonConverter());
        jsonOptions.Converters.Add(new JsonStringEnumConverter());
        
        services.AddRefitClient<IDebugApi>(new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(jsonOptions)
            })
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(baseAddress));

        return services;
    }
}