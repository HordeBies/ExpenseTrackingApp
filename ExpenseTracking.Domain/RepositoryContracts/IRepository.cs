using System.Linq.Expressions;

namespace ExpenseTracking.Domain.RepositoryContracts
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = false);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter, bool tracked = false);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveAsync();
    }
}
