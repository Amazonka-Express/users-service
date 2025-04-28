using Grpc.Core;

namespace Core.Exceptions.Base
{
    public class NotFoundException : BaseException
    {
        public override StatusCode StatusCode => StatusCode.NotFound;

        public NotFoundException(string key, params string[] args)
            : base(key, args) { }
    }
}
