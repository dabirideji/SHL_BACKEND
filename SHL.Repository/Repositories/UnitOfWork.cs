//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using SHL.Application.Interfaces;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.ChangeTracking;

//namespace SHL.Repository.Repositories
//{
//    public class UnitOfWork : SHL.Application.Interfaces.GenericRepositoryPattern.IUnitOfWork
//{
//    private readonly IServiceProvider _serviceProvider;
//    private readonly ICacheManager _cacheManager;
//    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

//        public DatabaseFacade Database => DbContext.Database;

//        public UnitOfWork(IServiceProvider serviceProvider, ICacheManager cacheManager)
//    {
//        _serviceProvider = serviceProvider;
//        _cacheManager = cacheManager;
//    }

//    private DbContext GetDbContext()
//    {
//        var dbContextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
//        return dbContextFactory.CreateDbContext();
//    }

//    public SHL.Application.Interfaces.GenericRepositoryPattern.IGenericRepository<T> GetRepository<T>() where T : class
//    {
//        if (!_repositories.ContainsKey(typeof(T)))
//        {
//            _repositories[typeof(T)] = new Lazy<SHL.Repository.Repositories.GenericRepositoryImplementations.GenericRepository<T>>(
//                () => new SHL.Repository.Repositories.GenericRepositoryImplementations.GenericRepository<T>(_cacheManager));
//        }
//        return ((Lazy<SHL.Repository.Repositories.GenericRepositoryImplementations.GenericRepository<T>>)_repositories[typeof(T)]).Value;
//    }

//    public async Task<int> SaveAsync()
//    {
//        using var dbContext = GetDbContext();
//        return await dbContext.SaveChangesAsync();
//    }

//    public void Dispose()
//    {
//        foreach (var repository in _repositories.Values)
//        {
//            if (repository is IDisposable disposableRepository)
//            {
//                disposableRepository.Dispose();
//            }
//        }
//    }

//        public int SaveChanges(bool acceptAllChangesOnSuccess)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public DbSet<TEntity> Set<TEntity>() where TEntity : class
//        {
//            throw new NotImplementedException();
//        }

//        public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
//        {
//            throw new NotImplementedException();
//        }

//        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
//        {
//            throw new NotImplementedException();
//        }

//        public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class
//        {
//            throw new NotImplementedException();
//        }

//        public EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
//        {
//            throw new NotImplementedException();
//        }

//        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
//        {
//            throw new NotImplementedException();
//        }

//        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class
//        {
//            throw new NotImplementedException();
//        }

//        public EntityEntry Add(object entity)
//        {
//            throw new NotImplementedException();
//        }

//        public ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public EntityEntry Attach(object entity)
//        {
//            throw new NotImplementedException();
//        }

//        public EntityEntry Update(object entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void AddRange(params object[] entities)
//        {
//            throw new NotImplementedException();
//        }

//        public Task AddRangeAsync(params object[] entities)
//        {
//            throw new NotImplementedException();
//        }

//        public void AttachRange(params object[] entities)
//        {
//            throw new NotImplementedException();
//        }

//        public void UpdateRange(params object[] entities)
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveRange(params object[] entities)
//        {
//            throw new NotImplementedException();
//        }

//        public void AddRange(IEnumerable<object> entities)
//        {
//            throw new NotImplementedException();
//        }

//        public Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public void AttachRange(IEnumerable<object> entities)
//        {
//            throw new NotImplementedException();
//        }

//        public void UpdateRange(IEnumerable<object> entities)
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveRange(IEnumerable<object> entities)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
































using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Repository.Repositories.GenericRepositoryImplementations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICacheManager _cacheManager;
        private readonly Dictionary<Type, object> _repositories = new();
        private DbContext _dbContext;

        private DbContext DbContext => _dbContext ??= GetDbContext();
        public DatabaseFacade Database => DbContext.Database;

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

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories[typeof(T)] = new Lazy<GenericRepository<T>>(
                    () => new GenericRepository<T>(_cacheManager));
            }

            return ((Lazy<GenericRepository<T>>)_repositories[typeof(T)]).Value;
        }

        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return DbContext.SaveChanges(acceptAllChangesOnSuccess);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return DbContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return DbContext.Set<TEntity>();
        }

        public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
        {
            return DbContext.Add(entity);
        }

        public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class
        {
            return DbContext.AddAsync(entity, cancellationToken);
        }

        public EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            return DbContext.Attach(entity);
        }

        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            return DbContext.Update(entity);
        }

        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class
        {
            return DbContext.Remove(entity);
        }

        public EntityEntry Add(object entity)
        {
            return DbContext.Add(entity);
        }

        public ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            return DbContext.AddAsync(entity, cancellationToken);
        }

        public EntityEntry Attach(object entity)
        {
            return DbContext.Attach(entity);
        }

        public EntityEntry Update(object entity)
        {
            return DbContext.Update(entity);
        }

        public EntityEntry Remove(object entity)
        {
            return DbContext.Remove(entity);
        }

        public void AddRange(params object[] entities)
        {
            DbContext.AddRange(entities);
        }

        public Task AddRangeAsync(params object[] entities)
        {
            return DbContext.AddRangeAsync(entities);
        }

        public void AttachRange(params object[] entities)
        {
            DbContext.AttachRange(entities);
        }

        public void UpdateRange(params object[] entities)
        {
            DbContext.UpdateRange(entities);
        }

        public void RemoveRange(params object[] entities)
        {
            DbContext.RemoveRange(entities);
        }

        public void AddRange(IEnumerable<object> entities)
        {
            DbContext.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
        {
            return DbContext.AddRangeAsync(entities, cancellationToken);
        }

        public void AttachRange(IEnumerable<object> entities)
        {
            DbContext.AttachRange(entities);
        }

        public void UpdateRange(IEnumerable<object> entities)
        {
            DbContext.UpdateRange(entities);
        }

        public void RemoveRange(IEnumerable<object> entities)
        {
            DbContext.RemoveRange(entities);
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return DbContext.Entry(entity);
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

            _dbContext?.Dispose();
        }
    }
}
