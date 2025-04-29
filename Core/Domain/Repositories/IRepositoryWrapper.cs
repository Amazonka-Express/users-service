namespace UsersService.Core.Domain.Repositories
{
    public interface IRepositoryWrapper
    {
        IUsersRepository Users { get; }
        Task Save();
    }
}
