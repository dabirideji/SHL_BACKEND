using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SHL.Domain.Models.Maps
{
    public class UserVerificationMap : IEntityTypeConfiguration<UserVerification>
    {
        public void Configure(EntityTypeBuilder<UserVerification> builder)
        {
            builder.ToTable("UserVerification");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.ApplicationUserId)
                   .IsRequired();

            builder.Property(u => u.CustomerNo).HasMaxLength(50);
            builder.Property(u => u.FirstName).HasMaxLength(100);
            builder.Property(u => u.LastName).HasMaxLength(100);
            builder.Property(u => u.OtherName).HasMaxLength(100);
            builder.Property(u => u.Holder_type).HasMaxLength(50);
            builder.Property(u => u.BVN).HasMaxLength(20);
            builder.Property(u => u.NIN).HasMaxLength(20);
            builder.Property(u => u.TIN).HasMaxLength(20);
            builder.Property(u => u.RC_No).HasMaxLength(20);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.Phone_no).HasMaxLength(20);
            builder.Property(u => u.Password).HasMaxLength(200);
            builder.Property(u => u.Source).IsRequired(false).HasMaxLength(50);
            builder.Property(u => u.InfoUpdateStatus).IsRequired(false).HasMaxLength(50);
            builder.Property(u => u.Sex).HasMaxLength(10);

            builder.Property(u => u.Email_Verified).HasDefaultValue(false);
            builder.Property(u => u.Phone_Verified).HasDefaultValue(false);
            builder.Property(u => u.IsTokenExpired).HasDefaultValue(false);
            builder.Property(u => u.IsFreeMode).HasDefaultValue(false);
            builder.Property(u => u.IsSent).HasDefaultValue(false);
            builder.Property(u => u.IsNotify).HasDefaultValue(false);
            builder.Property(u => u.IsActive).HasDefaultValue(true);
            builder.Property(u => u.IsSynched).HasDefaultValue(false);

            builder.Property(u => u.StateId);
            builder.Property(u => u.lgaId);
            builder.Property(u => u.CountryId);
            builder.Property(u => u.ZipCode).HasDefaultValue(false);
            builder.Property(u => u.StreetAddress).HasDefaultValue(false);

            builder.Property(u => u.DateCreated)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(u => u.ApplicationUser)
                   .WithOne(u=>u.UserVerification)
                   .HasForeignKey<UserVerification>(u => u.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.State)
            .WithMany(p => p.UserVerifications)
            .HasForeignKey(p => p.StateId);

            builder.HasOne(p => p.Lga)
             .WithMany(p => p.UserVerifications)
             .HasForeignKey(p => p.lgaId);

            builder.HasOne(p => p.Country)
           .WithMany(p => p.UserVerifications)
           .HasForeignKey(p => p.lgaId);


        }
    }
}
