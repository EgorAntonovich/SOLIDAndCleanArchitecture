using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Shared;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
{
    public int Id { get; set; }
}