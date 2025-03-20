using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class ShareholderMap : IEntityTypeConfiguration<Shareholder>
    {
        public void Configure(EntityTypeBuilder<Shareholder> builder)
        {
            builder.ToTable("tbl_Shareholder");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.CompanyId)
                .IsRequired();

            builder.Property(p => p.CscsNumber)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.ChnNumber)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.BrokerId)
                .IsRequired(false);

            builder.Property(p => p.ShareHolderEmployeeId)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.ShareholderPhoneNumber)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.ShareholderName)
               .HasMaxLength(100)
               .IsRequired(false);

            builder.Property(p => p.ShareholderAddress)
               .HasMaxLength(150)
               .IsRequired(false);

            builder.Property(p => p.ShareholderEmailAddress)
               .HasMaxLength(200)
               .IsRequired(false);

            builder.Property(p => p.Holding)
               .HasPrecision(18,2)
               .IsRequired();

            builder.Property(p => p.PercentageHolding)
                .HasPrecision(18,2)
               .IsRequired();
            #endregion

            builder.HasOne(p => p.Company)
                .WithMany(m => m.Shareholders)
                .HasForeignKey(f => f.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
