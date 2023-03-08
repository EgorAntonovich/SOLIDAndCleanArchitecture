using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public int NumberOfDays { get; set; }
    
    public LeaveType? LeaveType { get; set; }
    
    public int Period { get; set; }
}