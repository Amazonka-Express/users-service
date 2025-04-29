using System.Linq.Expressions;
using UsersService.Core.Domain.Entities;

namespace UsersService.Core.Domain.Repositories;

public interface IRepositoryBase<T>
    where T : BaseEntity, new()
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
