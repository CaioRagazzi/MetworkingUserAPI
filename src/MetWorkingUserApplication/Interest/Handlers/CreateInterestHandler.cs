using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interest.Commands;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Interest.Handlers
{
    public class CreateInterestHandler : IRequestHandler<CreateInterestCommand, BaseResponse<InterestResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public CreateInterestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;    
        }
        
        public async Task<BaseResponse<InterestResponse>> Handle(CreateInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = _mapper.Map<MetWorkingUserDomain.Entities.Interest>(request.CreateInterestRequest);

            await _applicationDbContext.Interest.AddAsync(interest);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var interestResponse = _mapper.Map<InterestResponse>(interest);
            var response = new BaseResponse<InterestResponse>();
            response.SetIsOk(interestResponse);

            return response;
        }
    }
}