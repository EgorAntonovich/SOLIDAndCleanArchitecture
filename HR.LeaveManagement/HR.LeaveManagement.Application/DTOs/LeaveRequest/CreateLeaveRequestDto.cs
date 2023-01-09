using System;
using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest
{
    public class CreateLeaveRequestDto : ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public int LeaveTypeId { get; set; }

        public string RequestComments { get; set; }
    }
}