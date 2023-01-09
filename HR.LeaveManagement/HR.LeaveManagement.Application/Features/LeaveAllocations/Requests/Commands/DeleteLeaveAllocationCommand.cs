using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveAllocations.Requests.Commands
{
    public class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}