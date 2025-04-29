namespace UsersService.Core.Services.Abstractions.Services
{
    public interface IServiceManager
    {
        IUsersService UserService { get; }
    }
}
