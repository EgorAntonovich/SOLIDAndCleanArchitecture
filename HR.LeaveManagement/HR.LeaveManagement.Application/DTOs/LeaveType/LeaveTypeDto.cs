using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveType
{
    public class LeaveTypeDto : BaseDto, ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}