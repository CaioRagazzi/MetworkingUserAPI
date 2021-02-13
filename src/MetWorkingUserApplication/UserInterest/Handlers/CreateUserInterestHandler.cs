using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Common.Exceptions;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.UserInterest.Commands;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.UserInterest.Handlers
{
    public class CreateUserInterestHandler : IRequestHandler<CreateUserInterestCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public CreateUserInterestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(CreateUserInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = await _applicationDbContext.Interest.FindAsync(request.UserInterestRequest.InterestId);
            var user = await _applicationDbContext.Users.FindAsync(request.UserInterestRequest.UserId);

            if (interest == null || user == null)
            {
                throw new NotFoundException();
            }

            var userInterests = _mapper.Map<UserInterests>(request.UserInterestRequest);

            await _applicationDbContext.UserInterests.AddAsync(userInterests);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}