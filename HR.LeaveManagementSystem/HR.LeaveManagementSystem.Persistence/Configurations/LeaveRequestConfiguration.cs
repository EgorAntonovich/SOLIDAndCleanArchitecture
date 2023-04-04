using HR.LeaveManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagementSystem.Persistence.Configurations;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.HasData(
            new LeaveRequest
            {
                Id = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
                LeaveTypeId = 1,
                DateRequested = DateTime.Now,
                RequestComments = "blablabla",
                Approved = true,
                Cancelled = false,
                RequestingEmployeeId = string.Empty,
            });
        
    }
}