using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company;
using SHL.Application.DTO.Staff;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.ViewModels;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHL.Application.IManagers;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CSL.Models.Identity;

namespace SHL.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICacheManager _cacheManager;
    private readonly IDatabaseContextAccessor _dbContextAccessor;
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public DatabaseFacade Database => throw new NotImplementedException();

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
                () => new GenericRepository<T>(_cacheManager));
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

    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public StaffRepository(ICacheManager cacheManager,
            UserManager<ApplicationUser> userManager) : base(cacheManager)
        {
            this.userManager = userManager;
        }

        public async Task<StaffProfileViewModel?> ProfileAsync(string subjectId)
        {
            var user = _context.Set<ApplicationUser>();
            var bank = _context.Set<StaffBank>();
            var profile = await (from s in _dbSet
                                 join u in user on s.CompanyUserId equals u.Id
                                 join b in bank on s.Id equals b.StaffId into staffBank
                                 where u.Id == subjectId
                                 from sb in staffBank.DefaultIfEmpty()
                                 select new StaffProfileViewModel
                                 {
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     StaffCode = s.StaffCode,
                                     StaffDepartment = s.StaffDepartment,
                                     StaffGrade = s.StaffGrade,
                                     CscsNumber = s.CscsNumber,
                                     ChnNumber = s.ChnNumber,
                                     PhoneNumber = u.PhoneNumber,
                                     AccountName = sb != null ? sb.AccountName : "",
                                     BankName = sb != null ? sb.BankName : "",
                                     AccountNumber = sb != null ? sb.AccountNumber : "",
                                     EmailAddress = u.Email,
                                 }).FirstOrDefaultAsync();

            return profile;
        }

        public async Task<StaffProfileViewModel?> ProfileByEmailAddressAsync(string emailAddress)
        {
            var user = _context.Set<CompanyUser>();
            var bank = _context.Set<StaffBank>();

            var profile = await (from s in _dbSet
                                 join u in user on s.CompanyUserId equals u.Id
                                 join b in bank on s.Id equals b.StaffId into staffBank
                                 where u.NormalizedEmail == emailAddress.ToUpperInvariant()
                                 from sb in staffBank.DefaultIfEmpty()
                                 select new StaffProfileViewModel
                                 {
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     StaffCode = s.StaffCode,
                                     StaffDepartment = s.StaffDepartment,
                                     StaffGrade = s.StaffGrade,
                                     CscsNumber = s.CscsNumber,
                                     ChnNumber = s.ChnNumber,
                                     PhoneNumber = u.PhoneNumber,
                                     AccountName = sb != null ? sb.AccountName : "",
                                     BankName = sb != null ? sb.BankName : "",
                                     AccountNumber = sb != null ? sb.AccountNumber : "",
                                     EmailAddress = u.Email,
                                     StaffStatus = u.StaffStatus

                                 }).FirstOrDefaultAsync();

            return profile;
        }

        public async Task<List<StaffProfileViewModel>> CompanyStaffsAsync(Guid companyId)
        {
            var user = _context.Set<CompanyUser>();
            var bank = _context.Set<StaffBank>();
           // var role = _context.Set<IdentityRole>();
           // var userRole = _context.Set<IdentityUserRole<string>>();

            var staffs = await (from s in _dbSet
                                join u in user on s.CompanyUserId equals u.Id
                                join b in bank on s.Id equals b.StaffId into staffBank                               
                                where s.CompanyId == companyId
                                from sb in staffBank.DefaultIfEmpty()
                                select new StaffProfileViewModel
                                {                                   
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    StaffCode = s.StaffCode,
                                    StaffDepartment = s.StaffDepartment,
                                    StaffGrade = s.StaffGrade,
                                    CscsNumber = s.CscsNumber,
                                    ChnNumber = s.ChnNumber,
                                    PhoneNumber = u.PhoneNumber,
                                    AccountName = sb != null ? sb.AccountName : "",
                                    BankName = sb != null ? sb.BankName : "",
                                    AccountNumber = sb != null ? sb.AccountNumber : "",
                                    EmailAddress = u.Email,
                                    StaffStatus = u.StaffStatus,
                                    IsAdmin = u.IsAdmin
                                }).ToListAsync();
            //foreach (var staff in staffs)
            //{
            //    var roles = await userManager.GetRolesAsync((await userManager.FindByIdAsync(staff.Id)));
            //    staff.IsAdmin = roles.Contains(Role)
            //}
            return staffs;
        }

        public async Task<string> UpdateStaffInfoAsync(UpdateEmployeeDto dto, CancellationToken cancellation)
        {
            var user = await userManager.FindByEmailAsync(dto.EmailAddress);
            if (user is null)
            {
                ApiException.ClientError("Staff with email not found");
                return "";
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.PhoneNumber = dto.PhoneNumber;


            await _dbSet.Where(u => u.CompanyUserId == user.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(u => u.StaffGrade, dto.StaffGrade)
                .SetProperty(u => u.StaffDepartment, dto.StaffDepartment)
                .SetProperty(u => u.CscsNumber, dto.CscsNumber)
                .SetProperty(u => u.ChnNumber, dto.ChnNumber)
                .SetProperty(s=>s.StaffCode,dto.StaffCode),
                cancellation);

          //  await userManager.UpdateAsync(user);

            return user.Id;
        }


    }
}
