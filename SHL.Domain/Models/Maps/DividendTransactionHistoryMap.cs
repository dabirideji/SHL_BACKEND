using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class DividendTransactionHistoryMap : IEntityTypeConfiguration<DividendTransactionHistory>
    {
        public void Configure(EntityTypeBuilder<DividendTransactionHistory> builder)
        {
            builder.ToTable("tbl_DividendTransactionHistory");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.DividendId)
                .IsRequired();

            builder.Property(p => p.EmployeeEmailAddress)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.EmployeeName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Amount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.TransactionDate)
                .IsRequired();
            #endregion

            builder.HasOne(p => p.Dividend)
                .WithMany(m => m.DividendTransactionHistories)
                .HasForeignKey(k => k.DividendId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
