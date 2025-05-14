using Api.Helpers;
using Core.Exceptions.Base;
using Core.Exceptions.Consts;
using Core.Logger;
using Grpc.Core;
using UserService;
using UsersService.Core.Services.Abstractions.Services;

namespace Api.Services;

public class UserRpcService : UserService.UserService.UserServiceBase
{
    private readonly ILoggerManager logger;
    private readonly IServiceManager serviceManager;

    public UserRpcService(IServiceManager serviceManager, ILoggerManager logger)
    {
        this.logger = logger;
        this.serviceManager = serviceManager;
    }

    public override async Task<User.User> GetUserByEmail(
        GetUserByEmailRequest request,
        ServerCallContext context
    )
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Email))
            throw new BadRequestException(ErrorMessages.InvalidArgument, nameof(request.Email));

        var user = await this.serviceManager.UserService.GetUserByEmail(request.Email);
        return RpcMapper.Map(user);
    }

    public override async Task<AuthenticateWithGoogleResponse> AuthenticateWithGoogle(
        AuthenticateWithGoogleRequest request,
        ServerCallContext context
    )
    {
        if (
            request == null
            || request.User == null
            || string.IsNullOrWhiteSpace(request.User.Email)
        )
            throw new BadRequestException(
                ErrorMessages.InvalidArgument,
                nameof(request.User.Email)
            );

        var (user, isNewUser) = await this.serviceManager.UserService.TryUpdateUser(
            RpcMapper.Map(request.User)
        );

        return new AuthenticateWithGoogleResponse()
        {
            User = RpcMapper.Map(user),
            IsNewUser = isNewUser,
        };
    }

    public override async Task<CreateUserResponse> Create(
        User.User request,
        ServerCallContext context
    )
    {
        var success = await this.serviceManager.UserService.CreateUser(RpcMapper.Map(request));
        return new CreateUserResponse() { Success = success != null };
    }

    public override async Task<DeleteUserResponse> Delete(
        DeleteUserRequest request,
        ServerCallContext context
    )
    {
        var success = await this.serviceManager.UserService.DeleteUser(request.Email);
        return new DeleteUserResponse() { Success = success };
    }
}
