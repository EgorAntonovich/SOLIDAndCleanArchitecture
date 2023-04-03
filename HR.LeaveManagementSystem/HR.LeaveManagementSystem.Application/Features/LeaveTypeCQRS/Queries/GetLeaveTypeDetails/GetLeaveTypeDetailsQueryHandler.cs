using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetLeaveTypeDetailsQueryHandler> _logger;

    public GetLeaveTypeDetailsQueryHandler(
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper,
        IAppLogger<GetLeaveTypeDetailsQueryHandler> logger)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
        this._logger = logger;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveTypeWithDetails = await _leaveTypeRepository.GetByIdAsync(request.Id);
        
        // Verify that record exists
        if (leaveTypeWithDetails == null)
        {
            _logger.LogWarning("LeaveType do not exists {0} - {1}", typeof(LeaveType), request.Id);
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }
        
        // Convert data object to DTO object
        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeWithDetails);
        _logger.LogInformation("LeaveType with details was successfully invoked.");
        // return DTO object
        return data;
    }
}