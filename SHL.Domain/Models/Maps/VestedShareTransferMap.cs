using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class VestedShareTransferMap : IEntityTypeConfiguration<VestedShareTransfer>
    {
        public void Configure(EntityTypeBuilder<VestedShareTransfer> builder)
        {
            builder.ToTable("tbl_VestedShareTransfer");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.CompanyId)
                .IsRequired();

            builder.Property(p => p.HolderEmailAddress)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.HolderName)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(p => p.OfferId)
                .IsRequired();

            builder.Property(p => p.TransferValue)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.CscsNumber)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.ChnNumber)
               .HasMaxLength(100)
               .IsRequired(false);

            builder.Property(p => p.BrokerId)
              .IsRequired(false);

            builder.Property(p => p.TransferDate)
                .IsRequired();

            builder.Property(p => p.ApprovalDate)
               .IsRequired(false);

            builder.Property(p => p.ProcessedDate)
               .IsRequired(false);

            builder.Property(p => p.ReferenceNumber)
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(p => p.Status)
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(p => p.DeclineComment)
                .HasMaxLength(100)
                .IsRequired(false);
            #endregion

            //builder.HasOne(p => p.Offer)
            //    .WithOne(o => o.VestedShareTransfer);
        }
    }
}
