using System;
using System.Collections.Generic;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.User.Queries
{
    public class GetTimelineQuery : IRequest<BaseResponse<List<UserResponse>>>
    {
        public GetTimelineQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}