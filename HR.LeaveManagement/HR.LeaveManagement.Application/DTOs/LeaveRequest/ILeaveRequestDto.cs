using System;

namespace HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest
{
    public interface ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
    }
}