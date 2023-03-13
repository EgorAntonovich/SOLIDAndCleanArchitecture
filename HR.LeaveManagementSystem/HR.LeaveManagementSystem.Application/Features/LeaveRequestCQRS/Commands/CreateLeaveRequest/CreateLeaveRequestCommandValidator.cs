using FluentValidation;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
{
    public CreateLeaveRequestCommandValidator()
    {
        RuleFor(command => command.LeaveType)
            .NotEmpty()
            .WithMessage("{PropertyName} property name is required.");

        RuleFor(command => command.Cancelled)
            .NotNull()
            .WithMessage("{PropertyName} property is required.");
    }
}