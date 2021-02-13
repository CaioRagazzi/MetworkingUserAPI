using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Interest.Commands
{
    public class DeleteInterestCommand : IRequest
    {
        public DeleteInterestCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}