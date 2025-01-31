using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N5_BE.Application.Interfaces;
using N5_BE.Infra.Data;

namespace N5_BE.Infra.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null)
        {
            return predicate == null
                ? _dbSet
                : _dbSet.Where(predicate);
        }
    }
}