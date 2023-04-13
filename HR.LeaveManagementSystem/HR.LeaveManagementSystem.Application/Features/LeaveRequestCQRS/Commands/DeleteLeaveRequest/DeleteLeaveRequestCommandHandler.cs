using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IAppLogger<DeleteLeaveRequestCommandHandler> _logger;

    public DeleteLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IAppLogger<DeleteLeaveRequestCommandHandler> logger)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._logger = logger;
    }
    
    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        // Retrieve domain entity object
        var leaveRequestToDelete = await _leaveRequestRepository.GetByIdAsync(request.Id);

        // Verify that object exists
        if (leaveRequestToDelete == null)
        {
            _logger.LogWarning("LeaveRequest for delete operation not exists {0} - 1}", nameof(LeaveRequest), request.Id);
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

            // Remove from database
        await _leaveRequestRepository.DeleteAsync(leaveRequestToDelete);
        _logger.LogWarning("LeaveRequest successfully deleted. {0} - {1}", nameof(LeaveRequest), request.Id);
        // Return Unit value
        return Unit.Value;
    }
}