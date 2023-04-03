using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public int DefaultDays { get; set; }
}