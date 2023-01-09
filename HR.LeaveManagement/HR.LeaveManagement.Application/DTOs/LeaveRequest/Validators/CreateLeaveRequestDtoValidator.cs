using FluentValidation;

namespace HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        
        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            
           Include(new ILeaveRequestDtoValidator(_leaveRequestRepository));
        }
    }
}