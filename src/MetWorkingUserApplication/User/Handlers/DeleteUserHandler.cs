using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Common.Exceptions;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public DeleteUserHandler(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _applicationDbContext.Users.Remove(entity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}