using System.Linq.Expressions;

namespace SHL.Application.Interfaces.GenericRepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task DeleteRangeAsync(List<T> entities);
    }
}
