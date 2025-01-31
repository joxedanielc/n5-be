using System.Linq.Expressions;

namespace N5_BE.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null);
    }
}