using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Email;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Application.Models.Email;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly IEmailSender _emailSender;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _logger;

    public UpdateLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IEmailSender emailSender,
        ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<UpdateLeaveRequestCommandHandler> logger)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._mapper = mapper;
        this._emailSender = emailSender;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest is null)
        {
            _logger.LogWarning("LeaveRequest for update not found {0} - {1}", nameof(LeaveRequest), request.Id);
        }
        
        // Verify incoming data
        var validator = new UpdateLeaveRequestCommandValidator(_leaveTypeRepository, _leaveRequestRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("LeaveRequest {0} - {1} for update not valid.", nameof(LeaveRequest), request.Id);
            throw new BadRequestException("Invalid LeaveRequest type", validationResult);
        }


        // Convert to domain entity
        var leaveRequestToUpdate = _mapper.Map<LeaveRequest>(request);

        // Update the database
        await _leaveRequestRepository.UpdateAsync(leaveRequestToUpdate);

        // Send confirmation email
        try
        {
            var email = new EmailMessage()
            {
                To = string.Empty,
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D}" +
                       $"has been updated successfully",
                Subject = "Leave Request Submitted"
            };
            
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }
        
        // Return Unit value
        return Unit.Value;
    }
}