using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.UserInterest.Queries;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserApplication.UserInterest.Handlers
{
    public class InterestComparsionHandler : IRequestHandler<InterestComparsionQuery, BaseResponse<InterestComparsionResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public InterestComparsionHandler(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<BaseResponse<InterestComparsionResponse>> Handle(InterestComparsionQuery request, CancellationToken cancellationToken)
        {
            var usersInterestDbSet = _applicationDbContext.UserInterests;

            var userInterestsList = await (from userInterests in usersInterestDbSet
                where userInterests.UserId == request.UserId
                select userInterests.InterestId).ToListAsync(cancellationToken);
            
            var userInterestsListFriends = await (from userInterests in usersInterestDbSet
                where  userInterestsList.Contains(userInterests.InterestId) && request.IdAmigos.IdAmigos.Contains(userInterests.UserId)
                select userInterests).ToListAsync(cancellationToken);

            var interestComparsionResponses = new InterestComparsionResponse();
            
            foreach (var userInterestsListFriend in userInterestsListFriends)
            {
                interestComparsionResponses.IdAmigos.Add(userInterestsListFriend.UserId);
            }

            var response = new BaseResponse<InterestComparsionResponse>();
            response.SetIsOk(interestComparsionResponses);

            return response;
        }
    }
}