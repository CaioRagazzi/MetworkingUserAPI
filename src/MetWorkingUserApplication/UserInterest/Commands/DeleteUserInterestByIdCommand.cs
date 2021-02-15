using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.UserInterest.Commands
{
    public class DeleteUserInterestByIdCommand : IRequest<BaseResponse<string>>
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