using System.ComponentModel.DataAnnotations;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommand : IRequest<Unit>
{
    [Required]
    public LeaveType? LeaveType { get; set; }
    
    public bool? Approved { get; set; }
    
    [Required]
    public bool Cancelled { get; set; }
}