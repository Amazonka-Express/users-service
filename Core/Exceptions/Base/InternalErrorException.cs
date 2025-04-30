using Grpc.Core;

namespace Core.Exceptions.Base
{
    public class InternalErrorException : BaseException
    {
        public override StatusCode StatusCode => StatusCode.Internal;

        public InternalErrorException(string name, params string[] args)
            : base(name, args) { }
    }
}
