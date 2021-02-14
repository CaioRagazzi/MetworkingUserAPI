using System.Collections.Generic;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Interest.Queries
{
    public class GetAllInterestQuery : IRequest<BaseResponse<IEnumerable<MetWorkingUserDomain.Entities.Interest>>>
    {
        
    }
}