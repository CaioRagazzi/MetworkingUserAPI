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
    public class GetUserInterestByUserIdHandler : IRequestHandler<GetUserInterestByUserIdQuery, BaseResponse<UserInterestResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public GetUserInterestByUserIdHandler(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        
        public async Task<BaseResponse<UserInterestResponse>> Handle(GetUserInterestByUserIdQuery request, CancellationToken cancellationToken)
        {
            var interests = _applicationDbContext.Interest;
            var userInterests = _applicationDbContext.UserInterests;
            
            var responseRequest = new BaseResponse<UserInterestResponse>();
            
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(uss => uss.Id == request.UserId,
                cancellationToken);
            
            if (user == null)
            {
                responseRequest.SetValidationErrors(new []{"User Not found!"});
                return responseRequest;
            }

            var query = await (from interest in interests
                join userInterest in userInterests on interest.Id equals userInterest.InterestId
                where userInterest.UserId == user.Id
                select interest).ToListAsync(cancellationToken);

            var response = new UserInterestResponse
            {
                UserId = user.Id,
                Interests = query,
                UserName = user.Name
            };
            
            responseRequest.SetIsOk(response);

            return responseRequest;
        }
    }
}