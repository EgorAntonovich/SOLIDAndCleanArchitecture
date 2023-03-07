using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetAllLeaveAllocations;

public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._mapper = mapper;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveAllocations = await _leaveAllocationRepository.GetAsync();

        // Convert data object to DTO object
        var data = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

        // Return list of DTO objects
        return data;
    }
}