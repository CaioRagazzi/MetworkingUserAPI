using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.User.Commands
{
    public class AuthenticateUserCommand: IRequest<BaseResponse<string>>
    {
        public AuthenticateUserCommand(AuthenticateUserRequest authenticateUserRequest)
        {
            AuthenticateUserRequest = authenticateUserRequest;
        }

        public AuthenticateUserRequest AuthenticateUserRequest { get; set; }
    }
}