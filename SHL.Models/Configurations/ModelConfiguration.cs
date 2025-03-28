using CSL.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Configurations
{

    public class DataValueConfiguration : IEntityTypeConfiguration<DataValue>
    {
        public void Configure(EntityTypeBuilder<DataValue> b)
        {
            b.Property(e => e.OnboardStatus)
            .HasColumnType("text");
        }
    }


}
