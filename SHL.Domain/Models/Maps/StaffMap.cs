using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("tbl_Staff");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p=>p.CompanyId)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p=>p.CompanyUserId)
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(p=>p.StaffCode)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.StaffDepartment)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.StaffGrade)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.StaffStatus)
                .IsRequired(false);

            builder.Property(p => p.CscsNumber)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.ChnNumber)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.Designation)
                .HasMaxLength(100)
                .IsRequired(false);

            #endregion

            #region Relationship
            builder.HasOne(o => o.CompanyUser)
                .WithOne(o => o.Staff);

            builder.HasOne(o=>o.Company)
                .WithMany(m=>m.Staffs)
                .HasForeignKey(k=>k.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
