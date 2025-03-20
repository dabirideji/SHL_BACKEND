using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class CompanyInfoMap : IEntityTypeConfiguration<CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyInfo> builder)
        {
            builder.ToTable("tbl_CompanyInfo");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.LogoUrl)
                .IsRequired(false);

            builder.Property(p => p.CompanyName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.CompanyCurrencyCode)
                .HasMaxLength(3)
                .HasDefaultValue("NGN")
                .IsRequired();

            builder.Property(p => p.Address)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.DomainName)
                .HasMaxLength(250)
                .IsRequired();
            #endregion
        }
    }
}
