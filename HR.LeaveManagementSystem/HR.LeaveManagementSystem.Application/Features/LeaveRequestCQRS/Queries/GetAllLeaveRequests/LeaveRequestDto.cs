using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetAllLeaveTypes;
using HR.LeaveManagementSystem.Domain;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;

public class LeaveRequestDto
{
    public DateTime StartDay { get; set; }

    public DateTime EndDate { get; set; }
    
    public LeaveTypeDto LeaveType { get; set; }

    public DateTime DateRequested { get; set; }
    
    public string RequestingEmployeeId { get; set; }
    
    public bool? Approved { get; set; }
}