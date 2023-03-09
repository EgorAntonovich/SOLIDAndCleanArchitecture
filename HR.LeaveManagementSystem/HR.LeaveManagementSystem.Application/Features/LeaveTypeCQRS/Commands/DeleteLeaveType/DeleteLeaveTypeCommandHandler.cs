using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exeptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Retrieve domain entity object
        var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

        // Verify that record exists
        if (leaveTypeToDelete == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        // Remove from database
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

        // Return Unit value
        return Unit.Value;
    }
}