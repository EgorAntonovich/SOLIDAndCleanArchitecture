using HR.LeaveManagementSystem.Application.Contracts.Email;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Application.Models.Email;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<CancelLeaveRequestCommandHandler> _logger;

    public CancelLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IEmailSender emailSender,
        IAppLogger<CancelLeaveRequestCommandHandler> logger)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._emailSender = emailSender;
        this._logger = logger;
    }

    public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
        
        if (leaveRequest is null)
        {
            _logger.LogWarning($"LeaveRequest {0} for cancellation not exists.", request.Id);
            throw new NotFoundException(nameof(leaveRequest), request.Id);
        }

        leaveRequest.Cancelled = true;
        
        try
        {
            var email = new EmailMessage()
            {
                To = string.Empty,
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D}" +
                       $"has been cancelled successfully",
                Subject = "Leave Request Cancelled"
            };
            
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }
        
        throw new NotImplementedException();
    }
}