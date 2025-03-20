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
    public class BrokerMap : IEntityTypeConfiguration<Broker>
    {
        public void Configure(EntityTypeBuilder<Broker> builder)
        {
            builder.ToTable("tbl_Broker");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.BrokerName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.EmailAddress)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(p => p.ContactPerson)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Address)
                .HasMaxLength(150)
                .IsRequired(false);

            #endregion

        }
    }
}
