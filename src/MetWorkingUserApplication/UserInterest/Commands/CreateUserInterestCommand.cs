using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.UserInterest.Commands
{
    public class CreateUserInterestCommand : IRequest<BaseResponse<string>>
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