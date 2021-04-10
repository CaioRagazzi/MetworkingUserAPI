using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserApplication.User.Handlers
{
    using Commands;
    using Contracts.Response;
    using Interfaces;

    public class BoostUserHandler : IRequestHandler<BoostUserCommand, BaseResponse<BoostUserResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        
        public BoostUserHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<BoostUserResponse>> Handle(BoostUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(usr =>
                usr.Id == request.BoostUserRequest.UserId, cancellationToken);

            var response = new BaseResponse<BoostUserResponse>();
            if (user == null)
            {
                response.SetValidationErrors(new []{"User does not exists"});
                return response;
            }
            var boostUserResponse = new BoostUserResponse("User has been queued to be Boosted");
            response.SetIsOk(boostUserResponse);

            return response;
        }
    }
}