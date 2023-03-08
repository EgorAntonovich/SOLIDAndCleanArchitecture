using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommand : IRequest<int>
{
    public LeaveType? LeaveType { get; set; }
    
    public bool? Approved { get; set; }
    
    public bool Cancelled { get; set; }
}