using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;

public class GetLeaveRequestsQueryHandler : IRequestHandler<GetLeaveRequestsQuery, List<LeaveRequestDto>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetLeaveRequestsQueryHandler> _logger;

    public GetLeaveRequestsQueryHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IAppLogger<GetLeaveRequestsQueryHandler> logger)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._mapper = mapper;
        this._logger = logger;
    }

    public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveRequests = await _leaveRequestRepository.GetAsync();

        // Convert data object to DTO object
        var data = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
        _logger.LogInformation("LeaveRequest successfully retrieved.");
        // Return list of DTO objects
        return data;
    }
}