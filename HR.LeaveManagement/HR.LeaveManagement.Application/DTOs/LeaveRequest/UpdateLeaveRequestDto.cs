using System;
using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseDto, ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public int LeaveTypeId { get; set; }

        public string RequestComments { get; set; }
        
        public bool Cancelled { get; set; }
    }
}