using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public int NumberOfDays { get; set; }
    
    public LeaveType? LeaveType { get; set; }
    
    public int Period { get; set; }
}