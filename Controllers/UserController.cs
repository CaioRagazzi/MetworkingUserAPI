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
        public User GetUserById(int id){
            var user = _userService.GetById(id);

            return user;
        }

        [HttpPost]
        public void Create([FromBody]User user)
        {
            _userService.Create(user);
        }
        
    }
}