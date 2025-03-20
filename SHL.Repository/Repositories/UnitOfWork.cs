using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHL.Application.IManagers;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Infrastructure.Repositories.GenericRepositoryImplementations;
public class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICacheManager _cacheManager;
    private readonly IDatabaseContextAccessor _dbContextAccessor;
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

    public UnitOfWork(IServiceProvider serviceProvider, ICacheManager cacheManager, IDatabaseContextAccessor dbContextAccessor)
    {
        _serviceProvider = serviceProvider;
        _cacheManager = cacheManager;
        _dbContextAccessor = dbContextAccessor;
    }

    private DbContext GetDbContext()
    {
        var dbContextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
        var dbContextType = _dbContextAccessor.GetDatabaseContextType();
        return dbContextFactory.CreateDbContext(dbContextType);
    }

    public IGenericRepository<T> GetRepository<T>() where T : class
    {
        if (!_repositories.ContainsKey(typeof(T)))
        {
            _repositories[typeof(T)] = new Lazy<GenericRepository<T>>(
                () => new GenericRepository<T>(GetDbContext(), _cacheManager));
        }
        return ((Lazy<GenericRepository<T>>)_repositories[typeof(T)]).Value;
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
}