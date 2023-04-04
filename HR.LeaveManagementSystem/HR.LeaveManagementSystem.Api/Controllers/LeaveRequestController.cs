using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CreateLeaveRequest;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.DeleteLeaveRequest;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.UpdateLeaveRequest;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetLeaveRequestDetails;
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
    public class LeaveRequestController : ControllerBase
    {
       private readonly IMediator _mediator;
        
        public LeaveRequestController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        // GET : api/<LeaveTypeController>
        [HttpGet]
        public async Task<List<LeaveRequestDto>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestsQuery());
            return leaveRequests;
        }
        
        // GET : api/<LeaveTypeController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LeaveRequestDetailsDto>> Get(int id)
        {
            var leaveRequestDetail = await _mediator.Send(new GetLeaveRequestDetailsQuery(id));
            return Ok(leaveRequestDetail);
        }
        
        // POST : api/<LeaveTypeController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLeaveRequestCommand createLeaveRequestCommand)
        {
            var leaveRequestResponse = await _mediator.Send(createLeaveRequestCommand);
            return CreatedAtAction(nameof(Get), new { id = leaveRequestResponse });
        }
        
        // PUT : api/<LeaveTypeController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveRequestCommand updateLeaveRequestCommand)
        {
            await _mediator.Send(updateLeaveRequestCommand);
            return NoContent();
        }
        
        // Delete : api/<LeaveTypeController>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var leaveRequestCommand = new DeleteLeaveRequestCommand() { Id = id };
            await _mediator.Send(leaveRequestCommand);
            return NoContent();
        }

    }
}
