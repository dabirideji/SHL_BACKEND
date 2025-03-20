using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models.Maps
{
    public class RoleMap : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole
               {
                   ConcurrencyStamp = "32a5a6e8-0ade-45fb-a751-f469e975b66d",
                   Name = Domain.Enums.Role.Employer.ToString(),
                   NormalizedName = Domain.Enums.Role.Employer.ToString().ToUpperInvariant(),
                   Id = "93be1e09-c686-4bb2-8e1b-8594f5585dd9"
               },
                 new IdentityRole
               {
                   ConcurrencyStamp = "2fca74f5-8568-4b34-ac21-5b8a91de0372",
                   Name = Domain.Enums.Role.Employee.ToString(),
                   NormalizedName = Domain.Enums.Role.Employee.ToString().ToUpperInvariant(),
                   Id = "acac7fb6-7c4a-4da8-a22e-47caab9928a9"
               }
            };

            builder.HasData(roles);
        }
    }
}
