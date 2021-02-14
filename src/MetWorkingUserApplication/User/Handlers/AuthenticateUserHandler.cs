using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.User.Commands;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserApplication.User.Handlers
{
    public class AuthenticateUserHandler: IRequestHandler<AuthenticateUserCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AuthenticateUserHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(usr =>
                usr.Email == request.AuthenticateUserRequest.UserEmail, cancellationToken);

            if (user == null)
            {
                return false;
            }

            var verified = BCrypt.Net.BCrypt.Verify(request.AuthenticateUserRequest.Password, user.Password);

            return verified;
        }
    }
}