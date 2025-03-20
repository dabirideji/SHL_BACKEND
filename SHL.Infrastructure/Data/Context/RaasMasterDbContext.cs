using Microsoft.EntityFrameworkCore;
using SHL.Domain.Models;

namespace SHL.Infrastructure.Data.Context
{
    public class SHLMasterDbContext : DbContext
    {
        //============== CONSTRUCTOR ===========
        public SHLMasterDbContext(DbContextOptions<SHLMasterDbContext> options) : base(options)
        {
        }
        //============== DATABASE TABLES ===============
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyDatabaseConnection> CompanyDatabaseConnections { get; set; }
        public DbSet<CompanySetting> CompanySettings { get; set; }
        public DbSet<CompanySubscription> CompanySubscriptions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationActivity> NotificationActivities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        //============================== CONFIGURATIONS ==================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any custom configurations for the entities here, e.g.,
            // modelBuilder.Entity<Company>().HasKey(c => c.Id);
        }
    }
}