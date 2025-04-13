using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHL.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SHL.Repository.Repositories
{
    public class UnitOfWork : SHL.Application.Interfaces.GenericRepositoryPattern.IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICacheManager _cacheManager;
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public DatabaseFacade Database => throw new NotImplementedException();

        public UnitOfWork(IServiceProvider serviceProvider, ICacheManager cacheManager)
    {
        _serviceProvider = serviceProvider;
        _cacheManager = cacheManager;
    }

    private DbContext GetDbContext()
    {
        var dbContextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
        return dbContextFactory.CreateDbContext();
    }

    public SHL.Application.Interfaces.GenericRepositoryPattern.IGenericRepository<T> GetRepository<T>() where T : class
    {
        if (!_repositories.ContainsKey(typeof(T)))
        {
            _repositories[typeof(T)] = new Lazy<SHL.Repository.Repositories.GenericRepositoryImplementations.GenericRepository<T>>(
                () => new SHL.Repository.Repositories.GenericRepositoryImplementations.GenericRepository<T>(_cacheManager));
        }
        return ((Lazy<SHL.Repository.Repositories.GenericRepositoryImplementations.GenericRepository<T>>)_repositories[typeof(T)]).Value;
    }

    public async Task<int> SaveAsync()
    {
        using var dbContext = GetDbContext();
        return await dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        foreach (var repository in _repositories.Values)
        {
            if (repository is IDisposable disposableRepository)
            {
                disposableRepository.Dispose();
            }
        }
    }

        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public EntityEntry Add(object entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public EntityEntry Attach(object entity)
        {
            throw new NotImplementedException();
        }

        public EntityEntry Update(object entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public void AttachRange(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void AttachRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }
    }
}
