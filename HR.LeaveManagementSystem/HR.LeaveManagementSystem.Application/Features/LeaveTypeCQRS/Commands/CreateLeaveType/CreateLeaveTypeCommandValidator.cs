using FluentValidation;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;

namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    
    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70)
            .WithMessage("{PropertyName} mus be fewer than 70 characters");

        RuleFor(command => command.DefaultDays)
            .GreaterThan(100)
            .WithMessage("{PropertyName} cannot exceed 100")
            .LessThan(1)
            .WithMessage("{PropertyName} cannot be less than 1");

        RuleFor(command => command)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave Type already exists.");

        this._leaveTypeRepository = leaveTypeRepository;
    }

    private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.IsLeaveTypeNameUnique(command.Name);
    }
}