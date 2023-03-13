using FluentValidation;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
    public UpdateLeaveRequestValidator()
    {
        RuleFor(command => command.LeaveType)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} property name is required.");

        RuleFor(command => command.Cancelled)
            .NotNull()
            .WithMessage("{PropertyName} property is required.");
    }
}