using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Commands
{
    public class CreateUserCommand : IRequest<BaseResponse<UserResponse>>
    {
        public CreateUserRequest UserRequest { get; }   

        public CreateUserCommand(CreateUserRequest userRequest)
        {
            UserRequest = userRequest;
        } 
        
    }
}