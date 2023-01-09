using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Contracts.Persistence.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public LeaveRequestDto? LeaveRequest { get; set; }

        public ChangeLeaveRequestApprovalDto? ChangeLeaveRequestApproval { get; set; }
    }
}