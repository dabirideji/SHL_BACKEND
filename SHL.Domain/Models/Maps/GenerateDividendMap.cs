using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class GenerateDividendMap : IEntityTypeConfiguration<GenerateDividend>
    {
        public void Configure(EntityTypeBuilder<GenerateDividend> builder)
        {
            builder.ToTable("tbl_GenerateDividend");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.EquityName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.DividendPerShare)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.TaxInPercentage)
               .HasPrecision(18, 2)
               .IsRequired();
            #endregion

        }
    }
}
