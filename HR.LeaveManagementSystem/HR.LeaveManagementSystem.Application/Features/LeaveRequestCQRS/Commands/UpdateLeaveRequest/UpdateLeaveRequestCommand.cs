using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommand : IRequest<Unit>
{
    public LeaveType? LeaveType { get; set; }
    
    public bool? Approved { get; set; }
    
    public bool Cancelled { get; set; }
}