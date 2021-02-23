using System;

namespace MetWorkingUserDomain.Entities
{
    public class UserInterests
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}