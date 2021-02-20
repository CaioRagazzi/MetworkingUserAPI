using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.User.Commands;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserApplication.User.Handlers
{
    public class AuthenticateUserHandler: IRequestHandler<AuthenticateUserCommand, BaseResponse<AuthenticateUserResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AuthenticateUserHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<AuthenticateUserResponse>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(usr =>
                usr.Email == request.AuthenticateUserRequest.UserEmail, cancellationToken);

            var response = new BaseResponse<AuthenticateUserResponse>();
            if (user == null)
            {
                response.SetValidationErrors(new []{"User does not exists"});
                return response;
            }
            
            var verified = BCrypt.Net.BCrypt.Verify(request.AuthenticateUserRequest.Password, user.Password);

            if (!verified)
            {
                response.SetIsForbidden();
                return response;
            }

            response.SetIsOk(new AuthenticateUserResponse(user.Id));
            
            return response;
        }
    }
}