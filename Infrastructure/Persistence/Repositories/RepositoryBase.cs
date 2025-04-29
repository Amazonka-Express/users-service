using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UsersService.Core.Domain.Entities;
using UsersService.Core.Domain.Repositories;

namespace UsersService.Infrastructure.Persistence.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : BaseEntity, new()
{
    protected RepositoryContext.RepositoryContext context;

    protected RepositoryBase(RepositoryContext.RepositoryContext context)
    {
        this.context = context;
    }

    public IQueryable<T> FindAll() => context.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        context.Set<T>().Where(expression).AsNoTracking();

    public void Create(T entity) => context.Set<T>().Add(entity);

    public void Update(T entity) => context.Set<T>().Update(entity);

    public void Delete(T entity) => context.Set<T>().Remove(entity);
}
