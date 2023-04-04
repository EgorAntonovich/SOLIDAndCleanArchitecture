using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.CreateLeaveType;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.DeleteLeaveType;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Commands.UpdateLeaveType;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetAllLeaveTypes;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetLeaveTypeDetails;
using HR.LeaveManagementSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public LeaveTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        // GET : api/<LeaveTypeController>
        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
            return leaveTypes;
        }
        
        // GET : api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailsDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
            return Ok(leaveType);
        }
        
        // POST : api/<LeaveTypeController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLeaveTypeCommand createLeaveTypeCommand)
        {
            var leaveTypeResponse = await _mediator.Send(createLeaveTypeCommand);
            return CreatedAtAction(nameof(Get), new { id = leaveTypeResponse });
        }
        
        // PUT : api/<LeaveTypeController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveTypeCommand updateLeaveTypeCommand)
        {
            await _mediator.Send(updateLeaveTypeCommand);
            return NoContent();
        }
        
        // Delete : api/<LeaveTypeController>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var leaveTypeCommand = new DeleteLeaveTypeCommand() { Id = id };
            await _mediator.Send(leaveTypeCommand);
            return NoContent();
        }

    }
}