using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CreateUserHandler(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _applicationDbContext.Users.Add(request.User);

            request.User.Password = BCrypt.Net.BCrypt.HashPassword(request.User.Password);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return request.User;
        }
    }
}