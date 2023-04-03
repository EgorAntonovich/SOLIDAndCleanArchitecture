using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<DeleteLeaveTypeCommandHandler> _logger;

    public DeleteLeaveTypeCommandHandler(
        ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<DeleteLeaveTypeCommandHandler> logger)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Retrieve domain entity object
        var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

        // Verify that record exists
        if (leaveTypeToDelete == null)
        {
            _logger.LogWarning("LeaveType for delete not found {0} - {1}", nameof(LeaveType), request.Id);
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        // Remove from database
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
        _logger.LogInformation("LeaveType was successful deleted.");
        // Return Unit value
        return Unit.Value;
    }
}