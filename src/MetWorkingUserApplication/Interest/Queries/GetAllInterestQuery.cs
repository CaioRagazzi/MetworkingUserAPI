using System.Collections.Generic;
using MediatR;

namespace MetWorkingUserApplication.Interest.Queries
{
    public class GetAllInterestQuery : IRequest<IEnumerable<MetWorkingUserDomain.Entities.Interest>>
    {
        
    }
}