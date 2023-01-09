using System;
using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.Common;
using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}