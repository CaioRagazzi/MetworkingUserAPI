using System;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.UserInterest.Commands;
using MetWorkingUserApplication.UserInterest.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MetWorkingUserPresentation.Controllers.UserInterest
{
    public class UserInterestController : ApiControllerBase
    {
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var query = new GetUserInterestByUserIdQuery(userId);
            var result = await Mediator.Send(query);

            return Ok(result);
        }
        
        [HttpPost("")]
        public async Task<IActionResult> Create([FromQuery]Guid userId, [FromQuery]Guid interestId)
        {
            var command = new CreateUserInterestCommand(userId, interestId);
            var result = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetByUserId), new { userId = result.UserId }, Unit.Value);
        }

        [HttpDelete("user/{userId}/interest/{interestId}")]
        public async Task<IActionResult> DeleteById(Guid userId, Guid interestId)
        {
            var command = new DeleteUserInterestByIdCommand(userId, interestId);
            var result = await Mediator.Send(command);

            return NoContent();
        }
    }
}