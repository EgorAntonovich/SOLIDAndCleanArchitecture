using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveRequests.Requests.Commands
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}