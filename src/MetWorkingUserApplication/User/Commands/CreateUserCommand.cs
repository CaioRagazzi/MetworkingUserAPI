using System;
using MediatR;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; }   

        public CreateUserCommand(User user)
        {
            User = user;
        } 
        
    }
}