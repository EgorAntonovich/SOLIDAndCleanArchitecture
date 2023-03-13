using FluentValidation;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
{
    public UpdateLeaveAllocationCommandValidator()
    {
        RuleFor(command => command.LeaveType)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(command => command.NumberOfDays)
            .LessThan(1)
            .WithMessage("{PropertyName} can't be less than 1.")
            .GreaterThan(100)
            .WithMessage("{PropertyName} can't be more than 100");
        
        RuleFor(command => command.Period)
            .LessThan(1)
            .WithMessage("{PropertyName} can't be less than 1.")
            .GreaterThan(100)
            .WithMessage("{PropertyName} can't be more than 100");
    }
}