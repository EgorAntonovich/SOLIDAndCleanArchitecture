using System.Collections.Generic;
using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {
        
    }
}