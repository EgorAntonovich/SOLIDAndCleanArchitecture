using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.Common;
using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto, ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}