using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestWithDetailsRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}