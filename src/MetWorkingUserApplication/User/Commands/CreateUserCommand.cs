using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Commands
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        public CreateUserRequest UserRequest { get; }   

        public CreateUserCommand(CreateUserRequest userRequest)
        {
            UserRequest = userRequest;
        } 
        
    }
}