using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}