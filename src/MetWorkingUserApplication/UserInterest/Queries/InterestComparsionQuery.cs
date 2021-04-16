using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.UserInterest.Queries
{
    public class InterestComparsionQuery : IRequest<BaseResponse<InterestComparsionResponse>>
    {
        public InterestComparsionQuery(Guid userId, InterestComparsionResponse idAmigo)
        {
            UserId = userId;
            IdAmigos = idAmigo;
        }
        public Guid UserId { get; set; }
        public InterestComparsionResponse IdAmigos { get; set; }
    }
}