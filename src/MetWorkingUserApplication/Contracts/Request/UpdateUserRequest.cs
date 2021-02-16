using System;

namespace MetWorkingUserApplication.Contracts.Request
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
    }   
}