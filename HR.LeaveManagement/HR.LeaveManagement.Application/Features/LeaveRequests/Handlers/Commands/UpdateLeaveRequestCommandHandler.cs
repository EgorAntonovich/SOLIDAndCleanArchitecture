using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            
            var validator = new UpdateLeaveRequestDtoValidator(_leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequest, cancellationToken);

            if (validationResult.IsValid == false)
                throw new Exception();
            
            if (request.LeaveRequest != null)
            {
                _mapper.Map(request.LeaveRequest, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApproval != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest,
                    request.ChangeLeaveRequestApproval.Approved);
            }
            
            return Unit.Value;
        }
    }
}