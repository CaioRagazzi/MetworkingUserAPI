using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Commands
{
    public class UpdateUserCommand : IRequest<UserResponse>
    {
        public UpdateUserRequest User { get; }

        public UpdateUserCommand(UpdateUserRequest user)
        {
            User = user;
        } 
        
    }
}