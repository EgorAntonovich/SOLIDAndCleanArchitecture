using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeaveRequestDto>>> Get()
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestListRequest());
        return Ok(leaveRequest);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto>> Get(int id)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestWithDetailsRequest { Id = id });
        return Ok(leaveRequest);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
    {
        var command = new CreateLeaveRequestCommand { LeaveRequest = leaveRequest };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromBody] LeaveRequestDto leaveRequest)
    {
        var command = new UpdateLeaveRequestCommand { LeaveRequest = leaveRequest };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveRequestCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}