using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CancelLeaveRequest;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.ChangeLeaveRequestApproval;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.CreateLeaveRequest;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.DeleteLeaveRequest;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Commands.UpdateLeaveRequest;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetLeaveRequestDetails;
using MediatR;
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
            var leaveRequestDetail = await _mediator.Send(new GetLeaveRequestDetailsQuery() {Id = id});
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
        
        // PUT : api/<LeaveTypeController>/CancelRequest/
        [HttpPut]
        [Route("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelRequest(CancelLeaveRequestCommand cancelLeaveRequestCommand)
        {
            await _mediator.Send(cancelLeaveRequestCommand);
            return NoContent();
        }
        
        // PUT : api/<LeaveTypeController>/UpdateApproval/
        [HttpPut]
        [Route("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateApproval(ChangeLeaveRequestApprovalCommand changeLeaveRequestApprovalCommand)
        {
            await _mediator.Send(changeLeaveRequestApprovalCommand);
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
