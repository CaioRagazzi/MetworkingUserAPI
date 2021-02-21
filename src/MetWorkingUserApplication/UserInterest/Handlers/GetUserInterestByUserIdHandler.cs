using System.Collections.Generic;
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
            var query = _applicationDbContext.UserInterests.Where(ui => ui.UserId == request.UserId).ToList();

            var responseRequest = new BaseResponse<UserInterestResponse>();
            // if (!query.Any())
            // {
            //     responseRequest.SetValidationErrors(new []{"Not found!"});
            //     return responseRequest;
            // }

            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(uss => uss.Id == request.UserId,
                cancellationToken);
            
            if (user == null)
            {
                responseRequest.SetValidationErrors(new []{"User Not found!"});
                return responseRequest;
            }
                        
            var response = new UserInterestResponse
            {
                UserId = user.Id,
                Interests = new List<MetWorkingUserDomain.Entities.Interest>(),
                UserName = user.Name
            };

            foreach (var item in query)
            {
                var interestToAdd = await _applicationDbContext.Interest.FirstOrDefaultAsync(it => it.Id == item.InterestId, cancellationToken);
                response.Interests.Add(interestToAdd);
            }
            responseRequest.SetIsOk(response);

            return responseRequest;
        }
    }
}