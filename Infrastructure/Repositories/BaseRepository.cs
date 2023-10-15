using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Movies.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MoviesDbContext _context;
        private DbSet<T> _entities;

        public BaseRepository(MoviesDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }


        public async Task Add(T entity, CancellationToken cancellationToken = default)
        {
            await Entities.AddAsync(entity, cancellationToken);
        }

        public async Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await Entities.AddRangeAsync(entities, cancellationToken);
        }

        public async Task Delete(T entity, CancellationToken cancellationToken = default)
        {
            Entities.Remove(entity);
        }

        public async Task DeleteRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            Entities.RemoveRange(entities);
        }

        public async Task<T> FindFirst(Expression<Func<T, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return Entities.AsQueryable();
        }

        public async Task<T> GetById(Guid Id)
        {
            return await Entities.FindAsync(Id);
        }

        public async Task Update(T entity, CancellationToken cancellationToken = default)
        {
            Entities.Update(entity);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return Entities.Any(predicate);
        }
    }
}
