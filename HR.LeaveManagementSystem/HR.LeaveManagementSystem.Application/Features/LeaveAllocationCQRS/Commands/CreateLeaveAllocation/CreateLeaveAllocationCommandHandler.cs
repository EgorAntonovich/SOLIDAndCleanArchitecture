using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.CreateLeaveType;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository  _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<CreateLeaveTypeCommandHandler> _logger;

    public CreateLeaveAllocationCommandHandler(
        ILeaveAllocationRepository leaveAllocationRepository,
        IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<CreateLeaveTypeCommandHandler> logger)
    {
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}", nameof(LeaveAllocation), request.LeaveTypeId);
            throw new BadRequestException("Invalid LeaveAllocation request", validationResult);
        }
        
        // Get LeaveType for allocations
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);
        
        // Convert to domain entity object
        var leaveAllocationToCreate = _mapper.Map<LeaveAllocation>(request);

        // Add to database
        await _leaveAllocationRepository.CreateAsync(leaveAllocationToCreate);
        _logger.LogInformation("LeaveAllocation created successfully");
        
        // Return record id
        return Unit.Value;
    }
}