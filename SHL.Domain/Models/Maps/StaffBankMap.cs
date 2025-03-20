using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class StaffBankMap : IEntityTypeConfiguration<StaffBank>
    {
        public void Configure(EntityTypeBuilder<StaffBank> builder)
        {
            builder.ToTable("tbl_StaffBank");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.StaffId)
                .IsRequired();

            builder.Property(p => p.BankName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.AccountNumber)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(p => p.SwitfCode)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.AccountName)
                .HasMaxLength(150)
                .IsRequired(false);
            #endregion

            builder.HasOne(b => b.Staff)
                .WithOne(o => o.Bank);
        }
    }
}
