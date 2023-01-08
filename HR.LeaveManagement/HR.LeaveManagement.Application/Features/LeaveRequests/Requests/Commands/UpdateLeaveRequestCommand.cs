using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public LeaveRequestDto? LeaveRequest { get; set; }

        public ChangeLeaveRequestApprovalDto? ChangeLeaveRequestApproval { get; set; }
    }
}