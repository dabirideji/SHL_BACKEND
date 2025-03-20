using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class ContractDocumentMap : IEntityTypeConfiguration<ContractDocument>
    {
        public void Configure(EntityTypeBuilder<ContractDocument> builder)
        {
            builder.ToTable("ContractDocument");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.EquityPlanId)
                .IsRequired();

            builder.Property(p => p.DocumentName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ContractDocumentType)
                .IsRequired();

            builder.Property(p => p.DocumentContentUrl)
                .IsRequired(false);

            builder.Property(p => p.DocumentContent)
                .IsRequired(false);


            #endregion

            #region Relationship
            builder.HasOne(p => p.EquityPlan)
                .WithMany(m => m.ContractDocuments)
                .HasForeignKey(f => f.EquityPlanId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
