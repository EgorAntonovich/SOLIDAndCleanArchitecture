using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        // Verify incoming data
        if()
        
        // Convert to domain entity
        var leaveAllocationToUpdate = _mapper.Map<LeaveAllocation>(request);

        // Update the database
        await _leaveAllocationRepository.UpdateAsync(leaveAllocationToUpdate);

        // Return Unit value
        return Unit.Value;
    }
}