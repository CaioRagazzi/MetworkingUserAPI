using System;
using System.Threading.Tasks;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.UserInterest.Commands;
using MetWorkingUserApplication.UserInterest.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MetWorkingUserPresentation.Controllers.UserInterest
{
    public class UserInterestController : ApiControllerBase
    {
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid interestId)
        {
            var query = new GetUserInterestByUserIdQuery(interestId);
            var result = await Mediator.Send(query);

            return Ok(result);
        }
        
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]UserInterestRequest userInterestRequest)
        {
            var command = new CreateUserInterestCommand(userInterestRequest);
            var result = await Mediator.Send(command);

            return Ok();
        }
    }
}