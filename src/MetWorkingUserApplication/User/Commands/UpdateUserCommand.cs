using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Commands
{
    public class UpdateUserCommand : IRequest<BaseResponse<UserResponse>>
    {
        public UpdateUserRequest UserUpdateRequest { get; }

        public UpdateUserCommand(UpdateUserRequest user)
        {
            UserUpdateRequest = user;
        } 
        
    }
}