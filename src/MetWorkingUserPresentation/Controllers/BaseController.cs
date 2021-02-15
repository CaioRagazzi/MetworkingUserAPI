using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace MetWorkingUserPresentation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        public async Task<IActionResult> ResponseBase<T>(BaseResponse<T> response)
        {
            if (response.Errors.data.Any()) return BadRequest(response);
            if (response.Errors.IsForbbiden) return Unauthorized(response);
            
            return Ok(response);
        }
    }
}