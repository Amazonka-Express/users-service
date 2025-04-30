using System.Net;
using Grpc.Core;

namespace Core.Exceptions.Base
{
    public class BadRequestException : BaseException
    {
        public override StatusCode StatusCode => StatusCode.InvalidArgument;

        public BadRequestException(string key, params string[] args)
            : base(key, args) { }
    }
}
