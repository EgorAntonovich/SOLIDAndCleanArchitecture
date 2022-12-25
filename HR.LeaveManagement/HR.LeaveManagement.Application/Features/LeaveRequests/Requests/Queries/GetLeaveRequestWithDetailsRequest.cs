using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestWithDetailsRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}