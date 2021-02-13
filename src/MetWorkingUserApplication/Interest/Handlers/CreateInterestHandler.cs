using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interest.Commands;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Interest.Handlers
{
    public class CreateInterestHandler : IRequestHandler<CreateInterestCommand, InterestResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public CreateInterestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;    
        }
        
        public async Task<InterestResponse> Handle(CreateInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = _mapper.Map<MetWorkingUserDomain.Entities.Interest>(request.CreateInterestRequest);

            await _applicationDbContext.Interest.AddAsync(interest);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<InterestResponse>(interest);
        }
    }
}