using Core.Exceptions.Base;
using Core.Logger;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Api.Middleware
{
    public class ExceptionInterceptor : Interceptor
    {
        private readonly ILoggerManager logger;

        public ExceptionInterceptor(ILoggerManager logger)
        {
            this.logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation
        )
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception exception)
            {
                throw HandleExceptionAsync(exception);
            }
        }

        private RpcException HandleExceptionAsync(Exception exception)
        {
            if (exception is BaseException baseException)
            {
                Console.WriteLine("testttt midd exc my");
                logger.LogError($"{baseException.StatusCode}: {exception.Message}");
                throw new RpcException(new Status(baseException.StatusCode, baseException.Message));
            }
            else
            {
                logger.LogError($"{exception.Message}");
                Console.WriteLine("testttt midd exc lol");
                throw new RpcException(new Status(StatusCode.Internal, exception.Message));
            }
        }
    }
}
