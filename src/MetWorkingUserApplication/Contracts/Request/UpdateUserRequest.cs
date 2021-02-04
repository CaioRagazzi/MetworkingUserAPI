using System;

namespace MetWorkingUserApplication.Contracts.Request
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }   
}