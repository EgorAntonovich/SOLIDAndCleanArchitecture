using System.Collections.Generic;
using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>> { }
}