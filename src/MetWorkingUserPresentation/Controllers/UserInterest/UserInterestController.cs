using System;
using System.Threading.Tasks;
using MetWorkingUserApplication.UserInterest.Commands;
using MetWorkingUserApplication.UserInterest.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MetWorkingUserPresentation.Controllers.UserInterest
{
    public class UserInterestController : ApiControllerBase
    {
        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var query = new GetUserInterestByUserIdQuery(userId);
            var result = await Mediator.Send(query);

            return await ResponseBase(result);
        }
        
        [HttpPost("")]
        public async Task<IActionResult> Create([FromQuery]Guid userId, [FromQuery]Guid interestId)
        {
            var command = new CreateUserInterestCommand(userId, interestId);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }

        [HttpDelete("User/{userId}/Interest/{interestId}")]
        public async Task<IActionResult> DeleteById(Guid userId, Guid interestId)
        {
            var command = new DeleteUserInterestByIdCommand(userId, interestId);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }
    }
}