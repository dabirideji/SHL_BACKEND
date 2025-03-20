using Microsoft.EntityFrameworkCore;
using SHL.Domain.Models;
using System.Reflection;

namespace SHL.Repository.Data.Context
{
    public class SHLMasterDbContext : DbContext
    {
        //============== CONSTRUCTOR ===========
        public SHLMasterDbContext(DbContextOptions<SHLMasterDbContext> options) : base(options)
        {
        }
        //============== DATABASE TABLES ===============
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        //public DbSet<AuditLog> AuditLogs { get; set; }
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<CompanyDatabaseConnection> CompanyDatabaseConnections { get; set; }
        //public DbSet<CompanySetting> CompanySettings { get; set; }
        //public DbSet<CompanySubscription> CompanySubscriptions { get; set; }
        //public DbSet<Notification> Notifications { get; set; }
        //public DbSet<NotificationActivity> NotificationActivities { get; set; }
        //public DbSet<Staff> Staffs { get; set; }
        //public DbSet<Subscription> Subscriptions { get; set; }
        //public DbSet<Token> Tokens { get; set; }
     

        //============================== CONFIGURATIONS ==================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region CompanyInfo
            modelBuilder.Entity<CompanyInfo>()
                .ToTable("tbl_CompanyInfo");

            #region Properties
            modelBuilder.Entity<CompanyInfo>().Property(p => p.Id)
                .IsRequired();

            modelBuilder.Entity<CompanyInfo>().Property(p => p.LogoUrl)
                .IsRequired(false);

            modelBuilder.Entity<CompanyInfo>().Property(p => p.CompanyName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<CompanyInfo>().Property(p => p.CompanyCurrencyCode)
                .HasMaxLength(3)
                .HasDefaultValue("NGN")
                .IsRequired();

            modelBuilder.Entity<CompanyInfo>().Property(p => p.Address)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<CompanyInfo>().Property(p => p.DomainName)
                .HasMaxLength(250)
                .IsRequired();

            modelBuilder.Entity<CompanyInfo>().Property(p => p.NormalizedDomainName)
               .HasMaxLength(250)
               .IsRequired();

            modelBuilder.Entity<CompanyInfo>().Property(p => p.ConnectionString)
                .IsRequired(false);

            modelBuilder.Entity<CompanyInfo>()
                .HasIndex(c => c.CompanyName)
                .IsUnique(true);

            modelBuilder.Entity<CompanyInfo>()
                .HasIndex(c => c.DomainName)
                .IsUnique(true);
            #endregion
            #endregion

        }
    }
}