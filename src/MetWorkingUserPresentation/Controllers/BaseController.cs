using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MetWorkingUserPresentation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        protected async Task<IActionResult> ResponseBase<T>(BaseResponse<T> response)
        {
            if (response.Errors.data.Count >= 1) return BadRequest(response);
            if (response.Errors.IsForbbiden) return Unauthorized(response);
            
            return Ok(response);
        }
    }
}