namespace MetWorkingUserApplication.Contracts.Request
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
    }   
}