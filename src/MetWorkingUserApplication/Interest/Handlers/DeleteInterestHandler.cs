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
    public class DeleteInterestHandler : IRequestHandler<DeleteInterestCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public DeleteInterestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(DeleteInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = await _applicationDbContext.Interest.FindAsync(request.Id);

            if (interest == null)
            {
                throw new NotFoundException();
            }

            _applicationDbContext.Interest.Remove(interest);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}