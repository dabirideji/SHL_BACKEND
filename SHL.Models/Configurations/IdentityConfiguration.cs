using CSL.Models.Accounts;
using CSL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSL.Models.Configurations
{

    #region Api Client Models:
    
    public class ApiClientConfiguration : IEntityTypeConfiguration<ApiClient>
    {
        public void Configure(EntityTypeBuilder<ApiClient> b)
        {
            b.Property(u => u.Client).IsRequired();
            b.Property(u => u.AppKey).IsRequired();
            b.Property(u => u.AppSecret).IsRequired();
            b.HasIndex(u => u.AppKey).IsUnique();
            b.HasIndex(u => u.AppSecret).IsUnique();
            b.ToTable("ApiClients");
        }
    }

    #endregion



    public class ApplicationPermissionConfiguration : IEntityTypeConfiguration<ApplicationPermission>
    {
        public void Configure(EntityTypeBuilder<ApplicationPermission> b)
        {
            b.Property(u => u.Name).IsRequired();
            b.Property(u => u.Code).IsRequired();
            b.HasIndex(u => u.Code).IsUnique();
            b.ToTable("AspNetPermissions");
        }
    }

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> b)
        {
            b.ToTable("AspNetUsers").Property(u => u.Email).HasMaxLength(100).IsRequired();
            b.HasIndex(u => u.Email).IsUnique();
        }
    }

    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> b)
        {
            b.ToTable("AspNetRoles");
        }
    }
    public class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<ApplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> b)
        {
            b.ToTable("AspNetUserClaims");
        }
    }
    public class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> b)
        {
            b.ToTable("AspNetRoleClaims");
        }
    }
    public class ApplicationRolePermissionConfiguration : IEntityTypeConfiguration<ApplicationRolePermission>
    {
        public void Configure(EntityTypeBuilder<ApplicationRolePermission> b)
        {
            b.HasKey(u => u.ID);
            b.HasIndex(u => new { u.ApplicationRoleId, u.ApplicationPermissionId }  );
            b.ToTable("AspNetRolePermissions");
        }
    }

    public class ApplicationUserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> b)
        {
            b.HasNoKey();
            b.ToTable("AspNetUserLogins");
        }
    }

    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> b)
        {
            b.HasNoKey();
            b.ToTable("AspNetUserRoles");
        }
    }

    public class ApplicationUserTokenConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> b)
        {
            b.HasNoKey();
            b.ToTable("AspNetUserTokens");
        }
    }

}
