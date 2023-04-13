using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public bool Approved { get; set; }
}