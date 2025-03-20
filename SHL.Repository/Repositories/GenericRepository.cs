
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SHL.Application.IManagers;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Repository.Data.Context;

namespace SHL.Repository.Repositories.GenericRepositoryImplementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ICacheManager _cacheManager;
        public readonly IUnitOfWork _context;
        public readonly DbSet<T> _dbSet;

        public GenericRepository(IUnitOfWork context, ICacheManager cacheManager)
        {
            _context = context;
            _cacheManager = cacheManager;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {

            await _dbSet.AddAsync(entity);
            await _cacheManager.ClearCache();
            await _cacheManager.RemoveAsync($"{typeof(T).Name}_All_0");
            var entry = _context.Entry(entity);

            return entity;
        }

        public async Task DeleteRangeAsync(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _cacheManager.ClearCache();
            await _cacheManager.RemoveAsync($"{typeof(T).Name}_All_0");
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
            var cacheKey = GenerateCacheKey($"{typeof(T).Name}_All", predicate);
            var cachedData = await _cacheManager.GetAsync<IEnumerable<T>>(cacheKey);
            if (cachedData != null && cachedData.Any())
            {
                return cachedData;
            }
            var data = predicate == null ? await _dbSet.ToListAsync() : await _dbSet.Where(predicate).ToListAsync();
            if (data.Any())
            {
                await _cacheManager.SetAsync(cacheKey, data, TimeSpan.FromMinutes(10));
            }
            return data;
        }

        public IQueryable<T> Get()
        {
            return _dbSet;
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);//.AsQueryable<T>();
        }
        public async Task<T?> GetByIdAsync(Guid id)
        {
            var cacheKey = GenerateCacheKey($"{typeof(T).Name}_ById", id);
            var cachedData = await _cacheManager.GetAsync<T>(cacheKey);
            if (cachedData != null)
            {
                return cachedData;
            }
            var data = await _dbSet.FindAsync(id);
            if (data != null)
            {
                await _cacheManager.SetAsync(cacheKey, data, TimeSpan.FromMinutes(10));
            }
            return data;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var cacheKey = GenerateCacheKey($"{typeof(T).Name}_Single", predicate);

            var cachedData = await _cacheManager.GetAsync<T>(cacheKey);
            if (cachedData != null)
            {
                return cachedData;
            }
            var data = await _dbSet.FirstOrDefaultAsync(predicate);
            if (data != null)
            {
                await _cacheManager.SetAsync(cacheKey, data, TimeSpan.FromMinutes(10));
            }
            return data;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //await _cacheManager.RemoveAsync($"{typeof(T).Name}_All");
            //await _cacheManager.ClearCache();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            await _cacheManager.RemoveAsync($"{typeof(T).Name}_All");
            return true;
        }

        private string GenerateCacheKey(string prefix, object? parameter = null)
        {
            var parameterHash = parameter?.ToString()?.GetHashCode() ?? 0;
            return $"{prefix}_{parameterHash}";
        }
    }
}