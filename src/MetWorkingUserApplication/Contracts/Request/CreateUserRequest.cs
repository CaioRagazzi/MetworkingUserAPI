using System;
using System.ComponentModel.DataAnnotations;
using MetWorkingUserDomain.Interfaces;

namespace MetWorkingUserApplication.Contracts.Request
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }   
}