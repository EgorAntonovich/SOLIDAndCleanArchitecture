using System.ComponentModel.DataAnnotations;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Shared;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
{
    public string RequestComments { get; set; }
}