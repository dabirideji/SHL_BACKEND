using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class EquityPlanMap : IEntityTypeConfiguration<EquityPlan>
    {
        public void Configure(EntityTypeBuilder<EquityPlan> builder)
        {
            builder.ToTable("EquityPlan");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.CompanyId)
                .IsRequired();

            builder.Property(p => p.PlanName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.TotalEquity)
                .HasPrecision(18,2)
                .IsRequired();

            builder.Property(p => p.Allocated)
                .HasPrecision(18,2)
                .IsRequired();

            builder.Property(p => p.UnAllocated)
                .HasPrecision(18,2)
                .IsRequired();

            builder.Property(p => p.PercentageTotalEquity)
                .HasPrecision(18,2)
                .IsRequired();

            builder.Property(p => p.PercentageAllocated)
               .HasPrecision(18,2)
               .IsRequired();

            #endregion

            #region Relationship
            builder.HasOne(c => c.Company)
                .WithMany(m => m.EquityPlans)
                .HasForeignKey(f => f.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
