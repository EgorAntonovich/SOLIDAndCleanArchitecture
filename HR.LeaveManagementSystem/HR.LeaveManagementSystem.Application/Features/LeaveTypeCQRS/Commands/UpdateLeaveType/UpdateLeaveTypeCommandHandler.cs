using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper,
        IAppLogger<UpdateLeaveTypeCommandHandler> logger)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
        this._logger = logger;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
            throw new BadRequestException("Invalid Leave Type", validationResult);
        }
        
        
        // Convert to domain entity
        var leaveTypeToUpdate = _mapper.Map<LeaveType>(request);

        // Update the database
        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
        _logger.LogInformation("Leave type was successfully updated");
        // Return Unit value
        return Unit.Value;
    } 
}