using Artisan.III.Server.Fakers;
using Artisan.III.Shared.Models.Catan;
using Microsoft.AspNetCore.Mvc;

namespace Artisan.III.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DebugController : Controller
{
    [HttpGet("error/{statusCode:int}")]
    public void Error(int statusCode)
    {
        Response.StatusCode = statusCode;
    }

    [HttpGet("alive")]
    public IActionResult IsAlive() => Ok();

    [HttpGet("catan")]
    public CatanFieldModel Catan(
        int? seed, 
        CatanGameExtensions extensions,
        [FromServices] IFaker<CatanFieldModel> faker)
    {
        return faker.Fake(seed, extensions);
    }
}