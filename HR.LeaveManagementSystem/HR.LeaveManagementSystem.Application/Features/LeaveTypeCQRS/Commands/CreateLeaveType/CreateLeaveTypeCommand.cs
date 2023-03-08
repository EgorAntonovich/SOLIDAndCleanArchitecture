using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.CreateLeaveType;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    
    public int DefaultDays { get; set; }
}