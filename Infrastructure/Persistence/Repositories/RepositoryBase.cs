using System.Linq.Expressions;
using Core.Logger;
using Microsoft.EntityFrameworkCore;
using UsersService.Core.Domain.Entities;
using UsersService.Core.Domain.Repositories;

namespace UsersService.Infrastructure.Persistence.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : BaseEntity, new()
{
    protected RepositoryContext.RepositoryContext context;
    protected ILoggerManager logger;

    protected RepositoryBase(RepositoryContext.RepositoryContext context, ILoggerManager logger)
    {
        this.context = context;
        this.logger = logger;
    }

    public IQueryable<T> FindAll() => context.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        context.Set<T>().Where(expression).AsNoTracking();

    public void Create(T entity)
    {
        logger.LogInfo($"Creating entity of type {typeof(T).Name}");
        context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        logger.LogInfo($"Updating entity of type {typeof(T).Name} and id {entity.Id}");
        context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        logger.LogInfo($"Deleting entity of type {typeof(T).Name} and id {entity.Id}");
        context.Set<T>().Remove(entity);
    }
}
