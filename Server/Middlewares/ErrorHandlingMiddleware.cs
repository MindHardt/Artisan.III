using Artisan.III.Server.Core.Exceptions;

namespace Artisan.III.Server.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = e switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,
                FormatException => StatusCodes.Status400BadRequest,

                NotFoundException => StatusCodes.Status404NotFound,

                NotAllowedException => StatusCodes.Status403Forbidden,

                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}