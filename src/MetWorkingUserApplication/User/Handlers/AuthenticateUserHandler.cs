using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.User.Commands;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserApplication.User.Handlers
{
    public class AuthenticateUserHandler: IRequestHandler<AuthenticateUserCommand, BaseResponse<string>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AuthenticateUserHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<string>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(usr =>
                usr.Email == request.AuthenticateUserRequest.UserEmail, cancellationToken);

            var response = new BaseResponse<string>();
            if (user == null)
            {
                response.Errors.Add("User does not exists");
                response.IsOk = false;
                return response;
            }
            
            var verified = BCrypt.Net.BCrypt.Verify(request.AuthenticateUserRequest.Password, user.Password);

            if (!verified)
            {
                response.Errors.Add("Forbidden");
                response.IsForbbiden = true;
                response.IsOk = false;
                return response;
            }
            
            return response;
        }
    }
}