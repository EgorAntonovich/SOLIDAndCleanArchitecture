using AutoMapper;
using FluentValidation;
using HR.LeaveManagementSystem.Application.Contracts.Email;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Exceptions;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;
using HR.LeaveManagementSystem.Application.Models.Email;
using HR.LeaveManagementSystem.Domain;
using MediatR;

namespace HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<CreateLeaveRequestCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;

    public CreateLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<CreateLeaveRequestCommandHandler> logger,
        IEmailSender emailSender)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
        this._emailSender = emailSender;
    }

    public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("LeaveRequest {0}  for create not valid.", nameof(LeaveRequest));
            throw new BadRequestException("Invalid LeaveRequest type", validationResult);
        }

        // Convert to domain entity object
        var leaveRequestToCreate = _mapper.Map<LeaveRequest>(request);
        
        // Add to database
        await _leaveRequestRepository.CreateAsync(leaveRequestToCreate);
        
        try
        {
            var email = new EmailMessage()
            {
                To = string.Empty,
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D}" +
                       $"has been created successfully",
                Subject = "Leave Request Submitted"
            };
            
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }
        
        // Return record id
        return Unit.Value;
    }
}