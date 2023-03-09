using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exeptions;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailsQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveTypeWithDetails = await _leaveTypeRepository.GetByIdAsync(request.Id);
        
        // Verify that record exists
        if (leaveTypeWithDetails == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }
        
        // Convert data object to DTO object
        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeWithDetails);
        
        // return DTO object
        return data;
    }
}