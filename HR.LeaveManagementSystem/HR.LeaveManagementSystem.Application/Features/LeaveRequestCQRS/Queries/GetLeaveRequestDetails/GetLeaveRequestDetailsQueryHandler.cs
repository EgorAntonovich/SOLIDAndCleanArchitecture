﻿using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, LeaveRequestDetailsDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }

    public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveRequestWithDetails = await _leaveRequestRepository.GetByIdAsync(request.Id);

        // Convert data object to DTO object
        var data = _mapper.Map<LeaveRequestDetailsDto>(leaveRequestWithDetails);
        
        // Return dto object
        return data;
    }
}