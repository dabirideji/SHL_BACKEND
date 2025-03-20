using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class DividendMap : IEntityTypeConfiguration<Dividend>
    {
        public void Configure(EntityTypeBuilder<Dividend> builder)
        {
            builder.ToTable("tbl_Dividend");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.EquityId)
                .IsRequired();

            builder.Property(p => p.EquityPlanName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.EmployeeEmailAddress)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.EmployeeName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.OfferValue)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.DividendValue)
               .HasPrecision(18, 2)
               .IsRequired();

            builder.Property(p => p.UnClaimedAmount)
               .HasPrecision(18, 2)
               .IsRequired();

            builder.Property(p => p.ClaimedAmount)
               .HasPrecision(18, 2)
               .IsRequired();

            builder.Property(p => p.TaxInPercentage)
              .HasPrecision(18, 2)
              .IsRequired();

            builder.Property(p => p.Status)
                .HasMaxLength(50)
                .IsRequired();

            #endregion

            builder.HasOne(p => p.GenerateDividend)
                .WithMany(m => m.Dividends)
                .HasForeignKey(k => k.GenerateDividendId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
