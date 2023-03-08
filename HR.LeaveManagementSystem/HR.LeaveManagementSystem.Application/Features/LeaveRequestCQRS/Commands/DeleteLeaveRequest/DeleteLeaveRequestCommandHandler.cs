using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
    {
        this._leaveRequestRepository = leaveRequestRepository;
    }
    
    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        // Retrieve domain entity object
        var leaveRequestToDelete = await _leaveRequestRepository.GetByIdAsync(request.Id);

        // Verify that object exists

        // Remove from database
        await _leaveRequestRepository.DeleteAsync(leaveRequestToDelete);

        // Return Unit value
        return Unit.Value;
    }
}