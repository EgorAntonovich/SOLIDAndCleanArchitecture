using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQuery : IRequest<LeaveRequestDetailsDto>
{
    public int Id { get; set; }
}