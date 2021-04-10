using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Contracts.Response;
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
        public async Task<IActionResult> Create([FromQuery] Guid userId, [FromQuery] Guid interestId)
        {
            var command = new CreateUserInterestCommand(userId, interestId);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }

        [HttpPost("interestCompare/{id}")]
        public async Task<IActionResult> InterestComparsion(Guid id, [FromBody] InterestComparsionRequest request)
        {
            List<InterestComparsionResponse> interestCompareResponse = new();
            var response = new BaseResponse<List<InterestComparsionResponse>>();

            foreach (var a in request.IdAmigos)
            {
                var query = new InterestComparsionQuery(id, a.IdAmigo);
                var result = await Mediator.Send(query);

                Guid guid = new("00000000-0000-0000-0000-000000000000");

                if (!result.IdAmigo.Equals(guid))
                {
                    interestCompareResponse.Add(result);
                }
            }

            response.SetIsOk(interestCompareResponse);

            return await ResponseBase(response);

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