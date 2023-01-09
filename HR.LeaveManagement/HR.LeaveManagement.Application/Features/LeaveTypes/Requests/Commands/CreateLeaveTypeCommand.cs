using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveType;
using HR.LeaveManagement.Application.Contracts.Persistence.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    { 
        public CreateLeaveTypeDto LeaveType { get; set; }
    }
}