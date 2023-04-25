using HR.LeaveManagementSystem.Domain;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;

public class LeaveRequestDto
{
    public int Id { get; set; }
    
    public DateTime StartDay { get; set; }

    public DateTime EndDate { get; set; }
    
    public LeaveType? LeaveType { get; set; }
    
    public int LeaveTypeId { get; set; }

    public DateTime DateRequested { get; set; }
    
    public string RequestingEmployeeId { get; set; } = string.Empty;
    
    public bool? Approved { get; set; }
}