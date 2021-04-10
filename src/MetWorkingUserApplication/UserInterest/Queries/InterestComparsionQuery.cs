using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.UserInterest.Queries
{
    public class InterestComparsionQuery : IRequest<InterestComparsionResponse>
    {
        public InterestComparsionQuery(Guid userId, Guid idAmigo)
        {
            UserId = userId;
            IdAmigo = idAmigo;
        }
        public Guid UserId { get; set; }
        public Guid IdAmigo { get; set; }
    }
}