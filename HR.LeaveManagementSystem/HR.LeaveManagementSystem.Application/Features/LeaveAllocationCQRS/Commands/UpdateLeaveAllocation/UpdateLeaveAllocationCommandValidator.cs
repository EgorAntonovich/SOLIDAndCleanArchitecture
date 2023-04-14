using FluentValidation;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;

namespace HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    public UpdateLeaveAllocationCommandValidator(
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveAllocationRepository = _leaveAllocationRepository;


        RuleFor(command => command.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeMustExists)
            .WithMessage("{PropertyName} does not exists");

        RuleFor(command => command.NumberOfDays)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be grater than {ComparisonValue}");

        RuleFor(command => command.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year)
            .WithMessage("{PropertyName} must be after {ComparisonValue}");

        RuleFor(command => command.Id)
            .NotNull()
            .MustAsync(LeaveAllocationMustExists)
            .WithMessage("{PropertyName} must be present");

    }

    private async Task<bool> LeaveTypeMustExists(int id, CancellationToken token)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
        return leaveType != null;
    }

    private async Task<bool> LeaveAllocationMustExists(int id, CancellationToken token)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(id);
        return leaveAllocation != null;
    }
}