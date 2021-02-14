using MediatR;
using MetWorkingUserApplication.Contracts.Request;

namespace MetWorkingUserApplication.User.Commands
{
    public class AuthenticateUserCommand: IRequest<bool>
    {
        public AuthenticateUserCommand(AuthenticateUserRequest authenticateUserRequest)
        {
            AuthenticateUserRequest = authenticateUserRequest;
        }

        public AuthenticateUserRequest AuthenticateUserRequest { get; set; }
    }
}