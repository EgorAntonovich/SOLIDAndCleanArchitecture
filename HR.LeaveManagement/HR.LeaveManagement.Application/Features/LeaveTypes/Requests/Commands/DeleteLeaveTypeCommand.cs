using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}