using System.Collections.Generic;
using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
        
    }
}