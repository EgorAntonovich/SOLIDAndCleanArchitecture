using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.DeleteLeaveAllocation;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<DeleteLeaveAllocationCommandHandler> _logger;

    public DeleteLeaveAllocationCommandHandler(
        ILeaveAllocationRepository leaveAllocationRepository,
        IMapper mapper,
        IAppLogger<DeleteLeaveAllocationCommandHandler> logger)
    {
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._mapper = mapper;
        this._logger = logger;
    }
    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        // Retrieve domain entity object
        var leaveAllocationToDelete = await _leaveAllocationRepository.GetByIdAsync(request.Id);

        // Verify that entity
        if (leaveAllocationToDelete == null)
        {
            _logger.LogWarning("LeaveAllocation with this Id {0} not exists for deletion.", request.Id);
            throw new NotFoundException(nameof(LeaveAllocation), request.Id);
        }
        

        // Remove from database
        await _leaveAllocationRepository.DeleteAsync(leaveAllocationToDelete);
        _logger.LogInformation("LeaveAllocation deleted successfully.");

        // Return Unit value
        return Unit.Value;
    }
}