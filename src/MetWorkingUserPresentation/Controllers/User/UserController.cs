using System;
using System.Threading.Tasks;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Queries;
using MetWorkingUserApplication.User.Commands;
using MetWorkingUserApplication.User.Queries;
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

            return await ResponseBase(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]CreateUserRequest user)
        {
            var command = new CreateUserCommand(user);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }

        [HttpPut("")]
        public async Task<IActionResult> Update(UpdateUserRequest user)
        {
            var command = new UpdateUserCommand(user);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }
        
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Create([FromBody]AuthenticateUserRequest user)
        {
            var command = new AuthenticateUserCommand(user);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }
        
        [HttpPut("{userId}/UpdateImage")]
        public async Task<IActionResult> Update([FromBody]UpdateUserImageRequest updateUserImageRequest, Guid userId)
        {
            var command = new UpdateUserImageCommand(updateUserImageRequest.ImageUrl, userId);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await Mediator.Send(query);

            return await ResponseBase(result);
        }
        
        [HttpPost("Boost")]
        public async Task<IActionResult> Boost([FromBody]BoostUserRequest boostUserRequest)
        {
            var command = new BoostUserCommand(boostUserRequest);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }

        [HttpGet("Timeline/{id}")]
        public async Task<IActionResult> GetTimeline([FromRoute] Guid id)
        {
            var query = new GetTimelineQuery(id);
            var result = await Mediator.Send(query);

            return await ResponseBase(result);
        }
        
    }
}