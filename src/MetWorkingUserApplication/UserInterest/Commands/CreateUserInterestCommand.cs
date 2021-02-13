using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.UserInterest.Commands
{
    public class CreateUserInterestCommand : IRequest
    {
        public CreateUserInterestCommand(UserInterestRequest userInterestRequest)
        {
            UserInterestRequest = userInterestRequest;
        }

        public UserInterestRequest UserInterestRequest { get; set; }
    }
}