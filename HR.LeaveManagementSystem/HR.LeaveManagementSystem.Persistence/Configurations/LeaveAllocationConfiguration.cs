using HR.LeaveManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagementSystem.Persistence.Configurations;

public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
{
    public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
    {
        builder.HasData(
            new LeaveAllocation
            {
                Id = 1,
                NumberOfDays = 10,
                LeaveTypeId = 1,
                Period = 100,
            });
    }
}