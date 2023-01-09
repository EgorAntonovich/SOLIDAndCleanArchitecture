using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto : ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }

        public int LeaveTypeId { get; set; }
        
        public int Period { get; set; }
    }
}