namespace MetWorkingUserApplication.Contracts.Response
{
    using System;

    public class AuthenticateUserResponse
    {
        public Guid UserId { get; set; }

        public AuthenticateUserResponse(Guid userId)
        {
            this.UserId = userId;
        }
    }
}