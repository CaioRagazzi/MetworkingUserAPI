using MediatR;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Interest.Commands
{
    public class UpdateInterestCommand : IRequest<InterestResponse>
    {
        public UpdateInterestRequest UpdateInterestRequest { get; set; }
        
        public UpdateInterestCommand(UpdateInterestRequest updateInterestRequest)
        {
            UpdateInterestRequest = updateInterestRequest;
        }
    }
}