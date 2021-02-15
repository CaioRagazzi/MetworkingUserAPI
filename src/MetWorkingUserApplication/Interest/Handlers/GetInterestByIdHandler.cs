using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interest.Queries;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Interest.Handlers
{
    public class GetInterestByIdHandler: IRequestHandler<GetInterestByIdQuery, BaseResponse<InterestResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetInterestByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        
        public async Task<BaseResponse<InterestResponse>> Handle(GetInterestByIdQuery request, CancellationToken cancellationToken)
        {
            var interest = await _applicationDbContext.Interest.FindAsync(request.Id);

            var response = new BaseResponse<InterestResponse>();
            if (interest == null)
            {
                response.SetValidationErrors(new []{"Interest not found!"});
                return response;
            }

            var interestResponse = _mapper.Map<InterestResponse>(interest);
            response.SetIsOk(interestResponse);

            return response;
        }
    }
}