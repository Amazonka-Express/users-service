using System.Net;

namespace Core.Exceptions.Base;

public abstract class BaseException : Exception
{
    public abstract Grpc.Core.StatusCode StatusCode { get; }

    public BaseException(string message, params string[] args)
        : base(string.Format(message, args)) { }
}
