using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class ExcerciseRequestMap : IEntityTypeConfiguration<ExcerciseRequest>
    {
        public void Configure(EntityTypeBuilder<ExcerciseRequest> builder)
        {
            builder.ToTable("tbl_ExcerciseRequest");
            builder.HasKey(k => k.Id);

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.OfferId)
                .IsRequired();

            builder.Property(p => p.HolderName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.HolderEmailAddress)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.PlanName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.PaymentReference)
                .HasMaxLength(450)
                .IsRequired(false);

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.Property(p => p.ExercisePrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.Tax)
               .HasPrecision(18, 2)
               .IsRequired();

            builder.Property(p => p.TotalCost)
               .HasPrecision(18, 2)
               .IsRequired();

            builder.Property(p => p.Status)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.DeclineReason)
               .HasMaxLength(100)
               .IsRequired(false);
            #endregion

            builder.HasOne(p => p.Offer)
                .WithMany(m => m.ExcerciseRequests)
                .HasForeignKey(k => k.OfferId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
