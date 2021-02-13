using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Interest.Commands
{
    public class CreateInterestCommand : IRequest<InterestResponse>
    {
        public CreateInterestRequest CreateInterestRequest { get; set; }

        public CreateInterestCommand(CreateInterestRequest createInterestRequest)
        {
            CreateInterestRequest = createInterestRequest;
        }
    }
}