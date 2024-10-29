using ModuleMonolith.Common.Domain;

namespace ModuleMonolith.Common.Application.Exceptions;

public sealed class ModuleMonolithException : Exception
{
    public ModuleMonolithException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
