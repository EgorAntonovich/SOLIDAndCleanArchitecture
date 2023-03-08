using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetLeaveAllocationDetails;

public record GetLeaveAllocationDetailsQuery(int Id) : IRequest<LeaveAllocationDetailsDto>;