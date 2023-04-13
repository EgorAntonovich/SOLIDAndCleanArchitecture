using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Email;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Application.Models.Email;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<ChangeLeaveRequestApprovalCommandHandler> _logger;

    public ChangeLeaveRequestApprovalCommandHandler(
        IMapper mapper,
        IEmailSender emailSender,
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<ChangeLeaveRequestApprovalCommandHandler> logger)
    {
        this._mapper = mapper;
        this._emailSender = emailSender;
        this._leaveRequestRepository = leaveRequestRepository;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest is null)
        {
            _logger.LogWarning($"LeaveRequest {0} for change approval does not exists.", request.Id);
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

        leaveRequest.Approved = request.Approved;
        await _leaveRequestRepository.UpdateAsync(leaveRequest);
        
        try
        {
            var email = new EmailMessage()
            {
                To = string.Empty,
                Body = $"Your leave request " +
                       $"has been updated successfully with changed approval status",
                Subject = "Leave Request Approval Status Updated"
            };
            
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }

        return Unit.Value;
    }
}