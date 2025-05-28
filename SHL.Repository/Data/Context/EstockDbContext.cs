using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace SHL.Repository.Data.Context
{
    public class EstockDbContext : DbContext
    {
        public EstockDbContext(DbContextOptions<EstockDbContext> options)
            : base(options)
        {
        }

        // DbSets for database views
        public DbSet<vwShareHolders> VwShareHolders { get; set; }
        public DbSet<vwCautionedAccounts> VwCautionedAccounts { get; set; }
        public DbSet<vwT_unitss> VwTUnitsses { get; set; }
        public DbSet<vwT_reg> vwT_reg { get; set; }
        public DbSet<vwT_reg_name> vwT_reg_name { get; set; }
        public DbSet<vwDividendPayment> VwDividendPayments { get; set; }
        public DbSet<vwBanks> VwBanks { get; set; }
        public DbSet<vwTprice> VwTprices { get; set; }
        public DbSet<vwUserPrivilege> VwUserPrivileges { get; set; }
        public DbSet<vwShareholderAccount> VwShareholderAccounts { get; set; }
        public DbSet<vwState> VwStates { get; set; }
        public DbSet<vwHolderType> VwHolderTypes { get; set; }
        public DbSet<vwDividendPaid> VwDividendPaids { get; set; }
        public DbSet<vwDividendType> VwDividendTypes { get; set; }
        public DbSet<vwSharePrice> VwSharePrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // If these are mapped to database views, configure them as query types:
            modelBuilder.Entity<vwShareHolders>().HasNoKey().ToView(nameof(VwShareHolders));
            modelBuilder.Entity<vwCautionedAccounts>().HasNoKey().ToView(nameof(VwCautionedAccounts));
            modelBuilder.Entity<vwT_unitss>().HasNoKey().ToView(nameof(VwTUnitsses));
            modelBuilder.Entity<vwT_reg>().HasNoKey().ToView(nameof(vwT_reg));
            modelBuilder.Entity<vwT_reg_name>().HasNoKey().ToView(nameof(vwT_reg_name));
            modelBuilder.Entity<vwDividendPayment>().HasNoKey().ToView(nameof(VwDividendPayments));
            modelBuilder.Entity<vwBanks>().HasNoKey().ToView(nameof(VwBanks));
            modelBuilder.Entity<vwTprice>().HasNoKey().ToView(nameof(VwTprices));
            modelBuilder.Entity<vwUserPrivilege>().HasNoKey().ToView(nameof(VwUserPrivileges));
            modelBuilder.Entity<vwShareholderAccount>().HasNoKey().ToView(nameof(VwShareholderAccounts));
            modelBuilder.Entity<vwState>().HasNoKey().ToView(nameof(VwStates));
            modelBuilder.Entity<vwHolderType>().HasNoKey().ToView(nameof(VwHolderTypes));
            modelBuilder.Entity<vwDividendPaid>().HasNoKey().ToView(nameof(VwDividendPaids));
            modelBuilder.Entity<vwDividendType>().HasNoKey().ToView(nameof(VwDividendTypes));
            modelBuilder.Entity<vwSharePrice>().HasNoKey().ToView(nameof(VwSharePrices));
        }
    }
}
