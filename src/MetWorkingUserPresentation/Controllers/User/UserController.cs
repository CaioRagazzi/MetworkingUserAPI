using System;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.Queries;
using MetWorkingUserDomain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MetWorkingUserPresentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]User user)
        {
            var command = new CreateUserCommand(user);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        
    }
}