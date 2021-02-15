using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interest.Commands;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Interest.Handlers
{
    public class UpdateInterestHandler : IRequestHandler<UpdateInterestCommand, BaseResponse<InterestResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public UpdateInterestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        
        public async Task<BaseResponse<InterestResponse>> Handle(UpdateInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = _mapper.Map<MetWorkingUserDomain.Entities.Interest>(request.UpdateInterestRequest);

            var interestInDb = await _applicationDbContext.Interest.FindAsync(interest.Id);

            var response = new BaseResponse<InterestResponse>();
            if (interestInDb == null)
            {
                response.SetValidationErrors(new []{"Interest not found!"});
                return response;
            }

            interestInDb.Description = interest.Description;
            interestInDb.Name = interest.Name;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            
            var interestResponse = _mapper.Map<InterestResponse>(interestInDb);
            response.SetIsOk(interestResponse);
            return response;
        }
    }
}