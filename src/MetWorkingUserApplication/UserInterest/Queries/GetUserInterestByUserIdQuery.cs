using System;
using System.Collections.Generic;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.UserInterest.Queries
{
    public class GetUserInterestByUserIdQuery : IRequest<UserInterestResponse>
    {
        public GetUserInterestByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }
    }
}