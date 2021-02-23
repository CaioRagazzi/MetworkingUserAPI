namespace MetWorkingUserApplication.User.Commands
{
    using Contracts.Request;
    using Contracts.Response;
    using MediatR;

    public class BoostUserCommand : IRequest<BaseResponse<BoostUserResponse>>
    {
        public BoostUserCommand(BoostUserRequest boostUserRequest)
        {
            BoostUserRequest = boostUserRequest;
        }

        public BoostUserRequest BoostUserRequest { get; set; }
    }
}