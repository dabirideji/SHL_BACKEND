using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SHL.Domain.Models;
using System.Reflection;

namespace SHL.Infrastructure.Data.Context
{
    public class SHLTennantDbContext : IdentityDbContext<CompanyUser>
    {
        //============== CONSTRUCTOR ===========
        public SHLTennantDbContext(DbContextOptions<SHLTennantDbContext> options) : base(options)
        {
        }

        //============== DATABASE TABLES ===============
        public DbSet<AuditLog> AuditLogs { get; set; }
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
        //public DbSet<User> Users { get; set; }
        public DbSet<UserCardDetail> UserCardDetails { get; set; }
       // public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Wallet> Wallets { get; set; }



        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<VestingSchedule> VestingSchedules { get; set; }
        public DbSet<VestingActivation> VestingActivations { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<OptionHolderSignature> OptionHolderSignatures { get; set; }


        //============================== CONFIGURATIONS ==================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add any custom configurations for the entities here, e.g.,
            // modelBuilder.Entity<Company>().HasKey(c => c.Id);

            modelBuilder.Entity<CompanyUser>()
                .ToTable("EquityPlanCompanyUser");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("EquityPlanRole");

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("EquityPlanUserClaim");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("EquityPlanUserLogin");

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("EquityPlanRoleClaim");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("EquityPlanUserToken");

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("EquityPlanUserRole");

            var typesToRegister = Assembly.Load("SHL.Domain");
            modelBuilder.ApplyConfigurationsFromAssembly(typesToRegister);
        }
    }


}
