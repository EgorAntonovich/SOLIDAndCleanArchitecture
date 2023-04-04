using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.CreateLeaveAllocation;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.DeleteLeaveAllocation;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.UpdateLeaveAllocation;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetAllLeaveAllocations;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.CreateLeaveType;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.DeleteLeaveType;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.UpdateLeaveType;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetAllLeaveTypes;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public LeaveAllocationController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        // GET : api/<LeaveTypeController>
        [HttpGet]
        public async Task<List<LeaveAllocationDto>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationsQuery());
            return leaveAllocations;
        }
        
        // GET : api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDetailsDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsQuery(id));
            return Ok(leaveAllocation);
        }
        
        // POST : api/<LeaveTypeController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLeaveAllocationCommand createLeaveAllocationCommand)
        {
            var leaveAllocationResponse = await _mediator.Send(createLeaveAllocationCommand);
            return CreatedAtAction(nameof(Get), new { id = leaveAllocationResponse });
        }
        
        // PUT : api/<LeaveTypeController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveAllocationCommand updateLeaveAllocationCommand)
        {
            await _mediator.Send(updateLeaveAllocationCommand);
            return NoContent();
        }
        
        // Delete : api/<LeaveTypeController>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var leaveAllocationCommand = new DeleteLeaveAllocationCommand() { Id = id };
            await _mediator.Send(leaveAllocationCommand);
            return NoContent();
        }

    }
}
