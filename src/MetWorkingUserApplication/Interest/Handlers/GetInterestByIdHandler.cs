using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Common.Exceptions;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interest.Queries;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Interest.Handlers
{
    public class GetInterestByIdHandler: IRequestHandler<GetInterestByIdQuery, InterestResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetInterestByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        
        public async Task<InterestResponse> Handle(GetInterestByIdQuery request, CancellationToken cancellationToken)
        {
            var interest = await _applicationDbContext.Interest.FindAsync(request.Id);

            if (interest == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<InterestResponse>(interest);
        }
    }
}