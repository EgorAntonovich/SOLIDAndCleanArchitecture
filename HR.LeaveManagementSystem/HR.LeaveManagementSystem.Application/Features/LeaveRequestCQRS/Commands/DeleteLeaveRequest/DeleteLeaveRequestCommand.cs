using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
}