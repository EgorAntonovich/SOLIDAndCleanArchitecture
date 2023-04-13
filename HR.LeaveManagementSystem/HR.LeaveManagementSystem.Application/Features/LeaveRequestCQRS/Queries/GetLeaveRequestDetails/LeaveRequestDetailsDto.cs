using HR.LeaveManagementSystem.Domain;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetLeaveRequestDetails;

public class LeaveRequestDetailsDto
{
    public DateTime StartDay { get; set; }

    public DateTime EndDate { get; set; }
    
    public LeaveType LeaveType { get; set; }
    
    public int LeaveTypeId { get; set; }
    
    public DateTime DateRequested { get; set; }
    
    public string? RequestComments { get; set; }
    
    public bool? Approved { get; set; }
    
    public bool Cancelled { get; set; }

    public string RequestingEmployeeId { get; set; }
    
    public DateTime? DateActioned { get; set; }
}