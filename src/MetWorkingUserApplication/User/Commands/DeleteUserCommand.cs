using System;
using MediatR;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}