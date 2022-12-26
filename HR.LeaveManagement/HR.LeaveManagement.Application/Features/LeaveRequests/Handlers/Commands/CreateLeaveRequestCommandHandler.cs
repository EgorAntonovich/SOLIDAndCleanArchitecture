using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDtoValidator(_leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequest, cancellationToken);

            if (validationResult.IsValid == false)
                throw new Exception();
            
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequest);

            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            return leaveRequest.Id;
        }
    }
}