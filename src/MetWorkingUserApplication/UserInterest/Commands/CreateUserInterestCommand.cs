using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.UserInterest.Commands
{
    public class CreateUserInterestCommand : IRequest<UserInterests>
    {
        public CreateUserInterestCommand(Guid userId, Guid interestId)
        {
            UserId = userId;
            InterestId = interestId;
        }

        public Guid UserId { get; set; }
        public Guid InterestId { get; set; }
    }
}