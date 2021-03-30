using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Infrastructure.Persistence.Configurations
{
    public partial class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Public",
                    NormalizedName = "PUBLIC"
                },
                new IdentityRole
                {
                    Name = "Company",
                    NormalizedName = "COMPANY"
                }
            );
        }
    }

}
