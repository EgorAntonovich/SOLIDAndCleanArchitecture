using FluentValidation;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Shared;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    public UpdateLeaveRequestCommandValidator(
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;
        Include(new BaseLeaveRequestValidator(_leaveTypeRepository));
        
        RuleFor(command => command.Id)
            .NotNull()
            .MustAsync(LeaveRequestMustExist)
            .WithMessage("{PropertyName} must be present.");
        
    }

    private async Task<bool> LeaveRequestMustExist(int id, CancellationToken token)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);
        return leaveRequest != null;
    }
}