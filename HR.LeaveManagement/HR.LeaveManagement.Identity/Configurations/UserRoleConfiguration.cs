using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(new IdentityUserRole<string>()
        {
            RoleId = "aadaadde-bea7-4bb9-bdf0-b3ab38f3a1cf",
            UserId = "fa55d408-1bbc-4c9e-ba77-db014845c466",
        }, new IdentityUserRole<string>()
        {
            RoleId = "7c1668c5-f0db-41e4-bf35-d3535749ad00",
            UserId = "5997b0ce-47bb-48c6-ba38-0c6f9401f922",
        });
    }
}