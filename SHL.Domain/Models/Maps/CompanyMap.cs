using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(p => p.CompanyName)
                 .HasMaxLength(150)
                 .IsRequired();

            builder.Property(p => p.CompanyEmailAddress)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(p => p.LogoUrl)
               .IsRequired(false);

            builder.Property(p => p.CompanyTotalShareAmount)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
