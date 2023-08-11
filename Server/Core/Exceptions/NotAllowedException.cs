using System.Diagnostics.CodeAnalysis;

namespace Artisan.III.Server.Core.Exceptions;

public class NotAllowedException : Exception
{
    public NotAllowedException(string? message, Exception? innerException = null) : base(message, innerException)
    { }

    /// <summary>
    /// Throws <see cref="NotAllowedException"/> with default text if <paramref name="condition"/> is <see langword="true"/>.
    /// </summary>
    /// <param name="condition"></param>
    /// <exception cref="NotAllowedException"></exception>
    public static void ThrowIf(
        [DoesNotReturnIf(true)] bool condition)
    {
        if (condition)
            throw new NotAllowedException(ExceptionResources.NotAllowedExceptionMessage);
    }
}