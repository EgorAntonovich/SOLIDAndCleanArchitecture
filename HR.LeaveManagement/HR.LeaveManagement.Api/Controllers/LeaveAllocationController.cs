using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveAllocations.Requests.Queries;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveAllocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveAllocationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocation>>> Get()
    {
        var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
        return Ok(leaveAllocations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocation>> Get(int id)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
        return Ok(leaveAllocation);
    }

    [HttpPost]
    public async Task<ActionResult<LeaveAllocationDto>> Post([FromBody] LeaveAllocationDto leaveAllocationDto)
    {
        var command = new CreateLeaveAllocationCommand { LeaveAllocation = leaveAllocationDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] LeaveAllocationDto leaveAllocationDto)
    {
        var command = new UpdateLeaveAllocationCommand { LeaveAllocation = leaveAllocationDto };
        var response = await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveAllocationCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}