using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class AppSettingMap : IEntityTypeConfiguration<AppSetting>
    {
        public void Configure(EntityTypeBuilder<AppSetting> builder)
        {
            builder.ToTable("tbl_AppSetting");

            #region Properties
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.CanEmployeeTransferShares)
                .IsRequired();

            builder.Property(p => p.AllowIncentive)
                            .IsRequired();

            builder.Property(p => p.ToggleRsuEquityType)
                            .HasDefaultValue(true)
                           .IsRequired();

            builder.Property(p => p.ToggleOptionsEquityType)
                           .IsRequired();

            builder.Property(p => p.ToggleSharePlan)
                           .IsRequired();

            builder.Property(p => p.ExerciseRequestTaxValue)
                .HasPrecision(18, 2)
                .IsRequired();
            #endregion

            #region Data
            builder.HasData(new[]
            {
                new AppSetting
                {
                     Id = Guid.Parse("820fbf71-5e1a-4bcc-8a22-be82309e1311"),
                     AllowIncentive= false,
                     CanEmployeeTransferShares=false,
                     ToggleOptionsEquityType= false,
                     ToggleRsuEquityType= true,
                     ToggleSharePlan = false,
                     CreatedAt= new DateTime(2025,03,05)
                }
            });
            #endregion
        }
    }
}
