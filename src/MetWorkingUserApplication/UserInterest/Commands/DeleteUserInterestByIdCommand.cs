using System;
using MediatR;

namespace MetWorkingUserApplication.UserInterest.Commands
{
    public class DeleteUserInterestByIdCommand : IRequest
    {
        public DeleteUserInterestByIdCommand(Guid userId, Guid interestId)
        {
            UserId = userId;
            InterestId = interestId;
        }

        public Guid UserId { get; set; }
        public Guid InterestId { get; set; }
        
    }
}