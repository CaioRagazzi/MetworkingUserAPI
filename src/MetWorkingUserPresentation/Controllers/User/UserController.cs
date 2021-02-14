using System;
using System.Threading.Tasks;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MetWorkingUserPresentation.Controllers.User
{
    public class UserController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]CreateUserRequest user)
        {
            var command = new CreateUserCommand(user);
            var result = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("")]
        public async Task<IActionResult> Update(UpdateUserRequest user)
        {
            var command = new UpdateUserCommand(user);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        
    }
}