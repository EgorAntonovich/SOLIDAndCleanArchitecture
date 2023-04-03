using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<CreateLeaveTypeCommandHandler> _logger;

    public CreateLeaveTypeCommandHandler(
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper,
        IAppLogger<CreateLeaveTypeCommandHandler> logger)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
        this._logger = logger;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Invalid LeaveType for creation {0} | {1} | ", nameof(LeaveType), request.Name, request.DefaultDays);
            throw new BadRequestException("Invalid LeaveType", validationResult);
        }
        
        // Convert to domain entity object
        var leaveTypeToCreate = _mapper.Map<LeaveType>(request);

        // Add to database
        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
        _logger.LogInformation("LeaveType was successfully created");
        // return record id
        return leaveTypeToCreate.Id;
    }
}