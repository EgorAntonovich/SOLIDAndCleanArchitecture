using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Contracts.Persistence.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto LeaveRequest { get; set; }
    }
}