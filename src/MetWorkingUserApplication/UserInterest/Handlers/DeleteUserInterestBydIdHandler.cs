using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Common.Exceptions;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.UserInterest.Commands;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserApplication.UserInterest.Handlers
{
    public class DeleteUserInterestBydIdHandler : IRequestHandler<DeleteUserInterestByIdCommand>
    {
        public DeleteUserInterestBydIdHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        
        public async Task<Unit> Handle(DeleteUserInterestByIdCommand request, CancellationToken cancellationToken)
        {
            var userInterestToDelete = await _applicationDbContext.UserInterests.FirstOrDefaultAsync(userInt =>
                    userInt.UserId == request.UserId && userInt.InterestId == request.InterestId, cancellationToken: cancellationToken);

            if (userInterestToDelete == null)
            {
                throw new NotFoundException();
            }

            _applicationDbContext.UserInterests.Remove(userInterestToDelete);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}