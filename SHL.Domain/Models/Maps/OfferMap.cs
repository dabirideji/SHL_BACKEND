using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class OfferMap : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offer");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.EquityPlanId)
                .IsRequired();

            builder.Property(p => p.OfferHolder)
                .HasComment("Fullname of the offer owner")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.EquityHolderEmailAddress)
                .IsRequired();

            builder.Property(p => p.OfferValue)
                .HasComment("Ownership")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.BalanceOfferValue)
               .HasPrecision(18, 2)
               .IsRequired();

            builder.Property(p => p.EstimatedOfferValue)
                .HasComment("Ownership in percentage")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.VestStartDate)
                .HasComment("date when vesting starts")
                .IsRequired();

            builder.Property(p => p.VestEndDate)
                .HasComment("date when vesting ends")
                .IsRequired();

            builder.Property(p => p.VestingPeriod)
                .HasComment("duration for vesting")
                .IsRequired();

            builder.Property(p => p.GrantDate)
                .HasComment("date when record was added")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasComment("such as awaiting, vesting, vested. Awaiting means offer while vesting and vested means Portfolio")
                .IsRequired();

            builder.Property(p => p.EquityPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.EstimatedValue)
               .HasPrecision(18, 2)
               .IsRequired();

            builder.Property(p => p.ExcercisePrice)
              .HasPrecision(18, 2)
              .IsRequired();

            builder.Property(p => p.IsOfferSigned)
                .IsRequired();

            builder.Property(p => p.SignatureUrl)
                .IsRequired(false);

            builder.Property(p => p.SignedDate)
                .IsRequired(false);

            builder.Property(p => p.SignedOfferUrl)
                .IsRequired(false);
            #endregion
        }
    }
}
