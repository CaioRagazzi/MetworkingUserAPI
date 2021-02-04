using System;
using System.ComponentModel.DataAnnotations;
using MetWorkingUserDomain.Interfaces;

namespace MetWorkingUserApplication.Contracts.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }   
}