using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(Guid Id);
        Task<T> FindFirst(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task Add(T entity, CancellationToken cancellationToken = default);
        Task AddRange(IEnumerable<T> entity, CancellationToken cancellationToken = default);
        Task Update(T entity, CancellationToken cancellationToken = default);
        Task Delete(T entity, CancellationToken cancellationToken = default);
        Task DeleteRange(IEnumerable<T> entity, CancellationToken cancellationToken = default);
    }
}
