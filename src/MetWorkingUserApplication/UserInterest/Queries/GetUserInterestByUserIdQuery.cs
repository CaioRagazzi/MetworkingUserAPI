using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.UserInterest.Queries
{
    public class GetUserInterestByUserIdQuery : IRequest<BaseResponse<UserInterestResponse>>
    {
        public GetUserInterestByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }
    }
}