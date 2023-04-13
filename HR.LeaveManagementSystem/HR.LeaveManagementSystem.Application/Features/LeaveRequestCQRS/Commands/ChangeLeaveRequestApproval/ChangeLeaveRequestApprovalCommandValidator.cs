using FluentValidation;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandValidator : AbstractValidator<ChangeLeaveRequestApprovalCommand>
{
    public ChangeLeaveRequestApprovalCommandValidator()
    {
        RuleFor(p => p.Approved)
            .NotNull()
            .WithMessage("Approval status cannot be null.");
    }
}