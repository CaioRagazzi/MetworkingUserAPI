namespace MetWorkingUserApplication.Contracts.Request
{
    public class AuthenticateUserRequest
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}