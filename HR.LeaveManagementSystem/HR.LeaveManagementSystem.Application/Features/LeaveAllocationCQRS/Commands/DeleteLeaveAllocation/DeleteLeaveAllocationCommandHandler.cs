using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exeptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.DeleteLeaveAllocation;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
    }
    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        // Retrieve domain entity object
        var leaveAllocationToDelete = await _leaveAllocationRepository.GetByIdAsync(request.Id);

        // Verify that entity
        if (leaveAllocationToDelete == null)
        {
            throw new NotFoundException(nameof(LeaveAllocation), request.Id);
        }
        

        // Remove from database
        await _leaveAllocationRepository.DeleteAsync(leaveAllocationToDelete);

        // Return Unit value
        return Unit.Value;
    }
}