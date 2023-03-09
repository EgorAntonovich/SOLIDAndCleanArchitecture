using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exeptions;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetAllLeaveAllocations;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationDetailsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._mapper = mapper;
    }

    public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query the Database
        var leaveAllocationWithDetails = await _leaveAllocationRepository.GetByIdAsync(request.Id);
        
        // Verify that records exists
        if (leaveAllocationWithDetails == null)
        {
            throw new NotFoundException(nameof(LeaveAllocation), request.Id);
        }

        // Convert data object to DTO object
        var data = _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocationWithDetails);
        
        // Return DTO object
        return data;
    }
}