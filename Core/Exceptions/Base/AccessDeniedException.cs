using Grpc.Core;

namespace Core.Exceptions.Base
{
    public class AccessDeniedException : BaseException
    {
        public override StatusCode StatusCode => StatusCode.PermissionDenied;

        protected AccessDeniedException(string name, params string[] args)
            : base(name, args) { }
    }
}
