using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Common.Exceptions;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interest.Commands;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Interest.Handlers
{
    public class UpdateInterestHandler : IRequestHandler<UpdateInterestCommand, InterestResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public UpdateInterestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        
        public async Task<InterestResponse> Handle(UpdateInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = _mapper.Map<MetWorkingUserDomain.Entities.Interest>(request.UpdateInterestRequest);

            var interestInDb = await _applicationDbContext.Interest.FindAsync(interest.Id);

            if (interestInDb == null)
            {
                throw new NotFoundException();
            }

            interestInDb.Description = interest.Description;
            interestInDb.Name = interest.Name;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<InterestResponse>(interestInDb);
        }
    }
}