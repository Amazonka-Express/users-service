using Core.Logger;
using UsersService.Core.Domain.Entities;
using UsersService.Core.Domain.Repositories;

namespace UsersService.Infrastructure.Persistence.Repositories;

public class UsersRepository : RepositoryBase<User>, IUsersRepository
{
    public UsersRepository(
        RepositoryContext.RepositoryContext repositoryContext,
        ILoggerManager logger
    )
        : base(repositoryContext, logger) { }
}
