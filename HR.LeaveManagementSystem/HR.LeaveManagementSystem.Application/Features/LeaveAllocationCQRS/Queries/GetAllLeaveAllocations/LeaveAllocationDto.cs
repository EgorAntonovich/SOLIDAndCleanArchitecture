using HR.LeaveManagementSystem.Domain;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetAllLeaveAllocations;

public class LeaveAllocationDto
{
    public int Id { get; set; }
    
    public int NumberOfDays { get; set; }
    
    public LeaveType? LeaveType { get; set; }
    
    public int Period { get; set; }
}