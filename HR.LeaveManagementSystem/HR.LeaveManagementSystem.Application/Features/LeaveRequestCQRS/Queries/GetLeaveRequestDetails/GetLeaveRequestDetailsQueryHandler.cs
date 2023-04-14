using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, LeaveRequestDetailsDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetLeaveRequestDetailsQueryHandler> _logger;

    public GetLeaveRequestDetailsQueryHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IAppLogger<GetLeaveRequestDetailsQueryHandler> logger)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._mapper = mapper;
        this._logger = logger;
    }

    public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveRequestWithDetails = await _leaveRequestRepository.GetByIdAsync(request.Id);
        
        // Verify that records exists
        if (leaveRequestWithDetails == null)
        {
            _logger.LogWarning("LeaveRequest {0} - {1} not exists.", nameof(LeaveRequest), request.Id);
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

        // Convert data object to DTO object
        var data = _mapper.Map<LeaveRequestDetailsDto>(leaveRequestWithDetails);
        _logger.LogInformation("LeaveRequest with details successfully retrieved.");
        // Return dto object
        return data;
    }
}