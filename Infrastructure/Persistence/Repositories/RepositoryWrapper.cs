using UsersService.Core.Domain.Repositories;

namespace UsersService.Infrastructure.Persistence.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly RepositoryContext.RepositoryContext repositoryContext;

    public RepositoryWrapper(RepositoryContext.RepositoryContext repositoryContext)
    {
        this.repositoryContext = repositoryContext;
        Users = new UsersRepository(repositoryContext);
    }

    public IUsersRepository Users { get; }

    public async Task Save()
    {
        await repositoryContext.SaveChangesAsync();
    }
}
