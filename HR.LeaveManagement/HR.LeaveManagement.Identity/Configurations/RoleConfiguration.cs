using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "7c1668c5-f0db-41e4-bf35-d3535749ad00",
                Name = "employee",
                NormalizedName = "EMPLOYEE"
            },
            new IdentityRole()
            {
                Id = "aadaadde-bea7-4bb9-bdf0-b3ab38f3a1cf",
                Name = "administrator",
                NormalizedName = "ADMINISTRATOR"
            });
    }
}