using AutoMapper;
using Core.Logger;
using UsersService.Core.Domain.Repositories;
using UsersService.Core.Services.Abstractions.Services;

namespace UsersService.Infrastructure.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IUsersService> userService;

    public ServiceManager(
        IRepositoryWrapper repositoryWrapper,
        IMapper mapper,
        ILoggerManager logger
    )
    {
        userService = new Lazy<IUsersService>(() =>
            new Services.UsersService(repositoryWrapper, mapper, logger)
        );
    }

    public IUsersService UserService => userService.Value;
}
