using System;
using System.Threading.Tasks;
using MetWorkingUserAPI.Interfaces;
using MetWorkingUserAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetWorkingUserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id){
            var user = await _userService.GetById(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]User user)
        {
            try
            {
                var createdUser = await _userService.Create(user);

                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.ToLower().Contains("duplicate"))
                {
                    return BadRequest(new {
                        Error = "User with the same e-mail already exists"
                    });
                } else {
                    return Problem(ex.Message);
                }
            }
        }
        
    }
}