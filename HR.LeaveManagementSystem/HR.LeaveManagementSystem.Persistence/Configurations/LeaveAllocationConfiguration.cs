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
                NumberOfDays = 10,
                LeaveType = new LeaveType(),
                Period = 100,
            });
    }
}