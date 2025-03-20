using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class DividendPayoutRequestMap : IEntityTypeConfiguration<DividendPayoutRequest>
    {
        public void Configure(EntityTypeBuilder<DividendPayoutRequest> builder)
        {
            builder.ToTable("tbl_DividendPayoutRequest");

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

            builder.Property(p => p.Status)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.DeclineComment)
               .HasMaxLength(100)
               .IsRequired(false);
            #endregion
        }
    }
}
