namespace MetWorkingUserApplication.User.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands;
    using Contracts.Response;
    using Interfaces;
    using MassTransit;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class BoostUserHandler : IRequestHandler<BoostUserCommand, BaseResponse<BoostUserResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        // private readonly IBus _bus;
        
        public BoostUserHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            // _bus = bus;
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

            // var endpoint = await _bus.GetSendEndpoint(new Uri("queue:user-boost-queue"));
            // await endpoint.Send(user, cancellationToken);
            var boostUserResponse = new BoostUserResponse("User has been queued to be Boosted");
            response.SetIsOk(boostUserResponse);

            return response;
        }
    }
}