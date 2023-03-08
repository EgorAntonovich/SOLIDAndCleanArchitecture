using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        // Verify incoming data
        
        // Convert to domain entity
        var leaveRequestToUpdate = _mapper.Map<LeaveRequest>(request);

        // Update the database
        await _leaveRequestRepository.UpdateAsync(leaveRequestToUpdate);

        // Return Unit value
        return Unit.Value;
    }
}