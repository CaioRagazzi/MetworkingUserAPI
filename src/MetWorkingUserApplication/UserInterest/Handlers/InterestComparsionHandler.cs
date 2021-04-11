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
    public class InterestComparsionHandler : IRequestHandler<InterestComparsionQuery, InterestComparsionResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public InterestComparsionHandler(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<InterestComparsionResponse> Handle(InterestComparsionQuery request, CancellationToken cancellationToken)
        {
            var query = _applicationDbContext.UserInterests.Where(ui => ui.UserId == request.UserId).ToList();
            var queryAmigo = _applicationDbContext.UserInterests.Where(ui => ui.UserId == request.IdAmigo).ToList();
            
            var responseRequest = new BaseResponse<InterestComparsionResponse>();

            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(uss => uss.Id == request.UserId,
                cancellationToken);

            var userAmigo = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.IdAmigo, cancellationToken);

            var response = new InterestComparsionResponse();
            
            if (user.Interest == null || userAmigo.Interest == null)
            {
                return response;
            }

            var commonInterest = false;

            foreach (var i in user.Interest)
            {
                foreach (var j in userAmigo.Interest)
                {
                    if (i.InterestId == j.InterestId)
                    {
                        commonInterest = true;
                        break;
                    }
                }

                if (commonInterest == true) break;
            }

            if (commonInterest == true) response.IdAmigo = request.IdAmigo;

            return response;
        }
    }
}