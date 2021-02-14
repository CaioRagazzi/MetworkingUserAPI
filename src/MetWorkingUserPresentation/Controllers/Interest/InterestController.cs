using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Interest.Commands;
using MetWorkingUserApplication.Interest.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MetWorkingUserPresentation.Controllers.Interest
{
    public class InterestController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetInterestByIdQuery(id);
            var result = await Mediator.Send(query);

            return Ok(result);
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllInterestQuery();
            var result = await Mediator.Send(query);

            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
        
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]CreateInterestRequest interest)
        {
            var command = new CreateInterestCommand(interest);
            var result = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteInterestCommand(id);
            var result = await Mediator.Send(command);

            return NoContent();
        }
        
        [HttpPut("")]
        public async Task<IActionResult> Update(UpdateInterestRequest user)
        {
            var command = new UpdateInterestCommand(user);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}