using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommand : IRequest<Unit>
{
    public int LeaveTypeId { get; set; }
}