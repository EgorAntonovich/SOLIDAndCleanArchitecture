using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;

public class GetLeaveRequestsQuery : IRequest<List<LeaveRequestDto>>
{
    
}