using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class CompanyUserMap : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> builder)
        {
            builder.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(p => p.StaffStatus)
                .HasDefaultValue(StaffStatus.ACTIVE.ToString())
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
