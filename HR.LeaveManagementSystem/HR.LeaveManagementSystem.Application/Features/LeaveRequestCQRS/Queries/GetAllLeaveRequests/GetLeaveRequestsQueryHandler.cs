using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;

public class GetLeaveRequestsQueryHandler : IRequestHandler<GetLeaveRequestsQuery, List<LeaveRequestDto>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._mapper = mapper;
    }

    public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveRequests = await _leaveRequestRepository.GetAsync();

        // Convert data object to DTO object
        var data = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
        
        // Return list of DTO objects
        return data;
    }
}