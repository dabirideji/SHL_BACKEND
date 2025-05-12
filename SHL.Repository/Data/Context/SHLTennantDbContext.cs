using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SHL.Application.IManagers;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;
using SHL.Domain.Models.Categories;
using SHL.Domain.Models.Identity;
using System.Reflection;

namespace SHL.Repository.Data.Context
{
    public class SHLTennantDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {

        private readonly IDbConnectionAccessor dbConnectionAccessor;
        private readonly IDbContextFactory _dbConnectionFactory;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SHLTennantDbContext(IDbConnectionAccessor dbConnectionAccessor,
            IHttpContextAccessor httpContextAccessor,
            IDbContextFactory dbConnectionFactory)
        {
            this.dbConnectionAccessor = dbConnectionAccessor;
            this.httpContextAccessor = httpContextAccessor;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public SHLTennantDbContext(DbContextOptions<SHLTennantDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var httpContext = httpContextAccessor?.HttpContext;
                var dbContextResultFromFactory = _dbConnectionFactory.CreateDbContext();
                var connectionStringFromFactory = dbContextResultFromFactory.Database.GetConnectionString();
                optionsBuilder.UseSqlServer(connectionStringFromFactory);
            }

            optionsBuilder.EnableSensitiveDataLogging(true)
                          .LogTo(Console.WriteLine, LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }



        //============== DATABASE TABLES ===============
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<FakeUser> FakeUsers { get; set; }
        public DbSet<Shareholder> Shareholders { get; set; }
        public DbSet<UploadedDocument> UploadedDocuments { get; set; }
        public DbSet<PoolDocument> PoolDocuments { get; set; }
        public DbSet<OptionHolder> OptionHolders { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CompanyDatabaseConnection> CompanyDatabaseConnections { get; set; }
        public DbSet<CompanySetting> CompanySettings { get; set; }
        public DbSet<CompanySubscription> CompanySubscriptions { get; set; }
        public DbSet<EmploymentDetail> EmploymentDetails { get; set; }
        public DbSet<ExcerciseSetting> ExcerciseSettings { get; set; }
        public DbSet<Grant> Grants { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationActivity> NotificationActivities { get; set; }
        public DbSet<OptionPool> OptionPools { get; set; }
        public DbSet<OptionPoolApproval> OptionPoolApprovals { get; set; }
        public DbSet<PayoutAccount> PayoutAccounts { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Wallet> Wallets { get; set; }



        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<VestingSchedule> VestingSchedules { get; set; }
        public DbSet<VestingActivation> VestingActivations { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<OptionHolderSignature> OptionHolderSignatures { get; set; }

        //public IGenericRepository<T> GetRepository<T>() where T : class
        //{
        //    if (!_repositories.ContainsKey(typeof(T)))
        //    {
        //        _repositories[typeof(T)] = new Lazy<GenericRepository<T>>(
        //            () => new GenericRepository<T>(GetDbContext(), _cacheManager));
        //    }
        //    return ((Lazy<GenericRepository<T>>)_repositories[typeof(T)]).Value;

        //}


        //============================== CONFIGURATIONS ==================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add any custom configurations for the entities here, e.g.,
            // modelBuilder.Entity<Company>().HasKey(c => c.Id);

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("shl_IdentityUser");

            modelBuilder.Entity<ApplicationRole>()
                .ToTable("shl_IdentitynRole");

            modelBuilder.Entity<ApplicationUserClaim>()
                .ToTable("shl_IdentityUserClaim");

            modelBuilder.Entity<ApplicationUserLogin>()
                .ToTable("shl_IdentityUserLogin");

            modelBuilder.Entity<ApplicationRoleClaim>()
                .ToTable("shl_IdentityRoleClaim");

            modelBuilder.Entity<ApplicationUserToken>()
                .ToTable("shl_IdentityUserToken");

            modelBuilder.Entity<ApplicationUserRole>()
                .ToTable("shl_IdentityUserRole");

            var typesToRegister = Assembly.Load("SHL.Domain");
            modelBuilder.ApplyConfigurationsFromAssembly(typesToRegister);
        }
    }


}
