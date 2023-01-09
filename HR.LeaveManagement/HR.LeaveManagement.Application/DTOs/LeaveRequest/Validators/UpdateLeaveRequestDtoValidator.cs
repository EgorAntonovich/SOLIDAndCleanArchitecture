using FluentValidation;

namespace HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            Include(new UpdateLeaveRequestDtoValidator(_leaveRequestRepository));
            RuleFor(p => p.LeaveTypeId).NotNull().WithMessage("{PropertyName must be present}");
        }
    }
}