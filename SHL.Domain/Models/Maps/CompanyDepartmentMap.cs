using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class CompanyDepartmentMap : IEntityTypeConfiguration<CompanyDepartment>
    {
        public void Configure(EntityTypeBuilder<CompanyDepartment> builder)
        {
            builder.ToTable("tbl_CompanyDepartment");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.CompanyId)
                .IsRequired();

            builder.Property(p => p.Department)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.NormalizedDepartment)
               .HasMaxLength(50)
               .IsRequired();
            #endregion

            builder.HasOne(p => p.Company)
                .WithMany(m => m.Departments)
                .HasForeignKey(k => k.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
