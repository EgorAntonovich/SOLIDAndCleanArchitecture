using System.ComponentModel.DataAnnotations;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommand : IRequest<int>
{
    [Required]
    public LeaveType? LeaveType { get; set; }
    
    public bool? Approved { get; set; }
    
    [Required]
    public bool Cancelled { get; set; }
}