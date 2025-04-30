using Api;
using Core.Exceptions.Base;
using Core.Logger;
using Grpc.Core;

namespace Api.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILoggerManager _logger;

    public GreeterService(ILoggerManager logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        _logger.LogInfo($"Saying hello to {request.Name}");
        return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
    }
}
