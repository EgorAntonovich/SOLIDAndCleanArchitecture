using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetAllLeaveAllocations;

public class GetLeaveAllocationsQuery : IRequest<List<LeaveAllocationDto>>
{
    
}