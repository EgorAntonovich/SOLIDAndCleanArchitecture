using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exeptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, LeaveRequestDetailsDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._mapper = mapper;
    }

    public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveRequestWithDetails = await _leaveRequestRepository.GetByIdAsync(request.Id);
        
        // Verify that records exists
        if (leaveRequestWithDetails == null)
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

        // Convert data object to DTO object
        var data = _mapper.Map<LeaveRequestDetailsDto>(leaveRequestWithDetails);
        
        // Return dto object
        return data;
    }
}