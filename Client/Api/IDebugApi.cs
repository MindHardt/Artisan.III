using Artisan.III.Shared.Models.Catan;
using Refit;

namespace Artisan.III.Client.Api;

public interface IDebugApi
{
    [Get("/api/Debug/catan")]
    Task<CatanFieldModel> GetCatanField(
        [Query] object? seed = null, 
        [Query] CatanGameExtensions extensions = CatanGameExtensions.None);
}