using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interest.Queries;
using MetWorkingUserApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserApplication.Interest.Handlers
{
    public class GetAllInterestsHandler : IRequestHandler<GetAllInterestQuery, BaseResponse<IEnumerable<MetWorkingUserDomain.Entities.Interest>>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllInterestsHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<IEnumerable<MetWorkingUserDomain.Entities.Interest>>> Handle(GetAllInterestQuery request, CancellationToken cancellationToken)
        {
            var interests = await _applicationDbContext.Interest.ToListAsync(cancellationToken);

            var response = new BaseResponse<IEnumerable<MetWorkingUserDomain.Entities.Interest>>();
            response.Data = interests;
            
            return response;
        }
    }
}