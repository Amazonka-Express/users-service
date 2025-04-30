using System.Net;
using Grpc.Core;

namespace Core.Exceptions.Base
{
    public class ConflictException : BaseException
    {
        public override StatusCode StatusCode => StatusCode.AlreadyExists;

        public ConflictException(string key, params string[] args)
            : base(key, args) { }
    }
}
