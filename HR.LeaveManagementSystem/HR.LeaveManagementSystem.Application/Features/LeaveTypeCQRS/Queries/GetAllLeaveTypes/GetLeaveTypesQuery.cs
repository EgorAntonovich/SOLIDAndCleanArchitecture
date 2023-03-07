using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
{
    
}