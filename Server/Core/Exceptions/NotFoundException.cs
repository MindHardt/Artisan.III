using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Artisan.III.Server.Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string? message, Exception? innerException = null) : base(message, innerException)
    { }

    /// <summary>
    /// Throws <see cref="NotFoundException"/> if <paramref name="value"/> is null.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <exception cref="NotFoundException"></exception>
    public static void ThrowIfNull(
        [NotNull] object? value, 
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (value is null)
            throw new NotFoundException(string.Format(ExceptionResources.NotFoundExceptionMessage, paramName));
    }
}