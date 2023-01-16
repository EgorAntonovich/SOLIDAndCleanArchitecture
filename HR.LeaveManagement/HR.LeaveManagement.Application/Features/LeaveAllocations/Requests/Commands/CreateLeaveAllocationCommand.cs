using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Contracts.Persistence.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto LeaveAllocation { get; set; }
    }
}