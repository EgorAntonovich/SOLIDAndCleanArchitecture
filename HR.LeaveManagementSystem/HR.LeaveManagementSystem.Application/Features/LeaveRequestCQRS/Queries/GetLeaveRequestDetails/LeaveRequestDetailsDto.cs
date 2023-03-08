using HR.LeaveManagementSystem.Domain;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetLeaveRequestDetails;

public class LeaveRequestDetailsDto
{
    public int Id { get; set; }
    
    public DateTime StartDay { get; set; }

    public DateTime EndDate { get; set; }
    
    public LeaveType? LeaveType { get; set; }
    
    public int LeaveTypeId { get; set; }
    
    public DateTime DateRequested { get; set; }
    
    public string? RequestComments { get; set; }
    
    public bool? Approved { get; set; }
    
    public bool Cancelled { get; set; }

    public string RequestingEmployeeId { get; set; } = string.Empty;
    
    public DateTime? DateCreated { get; set; }
    
    public DateTime? DateModified { get; set; }
}