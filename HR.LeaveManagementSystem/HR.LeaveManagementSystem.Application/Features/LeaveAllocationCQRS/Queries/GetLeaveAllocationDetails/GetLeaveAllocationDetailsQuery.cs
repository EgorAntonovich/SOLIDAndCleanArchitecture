using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailsQuery : IRequest<LeaveAllocationDetailsDto>
{
    public int Id { get; set; }
}