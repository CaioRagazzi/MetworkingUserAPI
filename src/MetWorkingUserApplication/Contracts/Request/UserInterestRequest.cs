using System;

namespace MetWorkingUserApplication.Contracts.Request
{
    public class UserInterestRequest
    {
        public UserInterestRequest(Guid userId, Guid interestId)
        {
            UserId = userId;
            InterestId = interestId;
        }

        public Guid UserId { get; set; }
        public Guid InterestId { get; set; }
    }
}