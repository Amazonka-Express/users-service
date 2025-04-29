using AutoMapper;
using Core.Logger;
using UsersService.Core.Domain.Repositories;
using UsersService.Core.Services.Abstractions.Services;
using UsersService.Infrastructure.Services.Helpers;

namespace UsersService.Infrastructure.Services.Services
{
    public class ServiceBase : IServiceBase
    {
        protected readonly IRepositoryWrapper repositoryWrapper;
        protected readonly ILoggerManager logger;
        protected readonly PermissionsManager permissionsManager;
        protected readonly IMapper mapper;

        public ServiceBase(
            IRepositoryWrapper repositoryWrapper,
            IMapper mapper,
            ILoggerManager logger
        )
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
            this.logger = logger;
            permissionsManager = new(logger);
        }
    }
}
