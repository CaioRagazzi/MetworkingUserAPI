using System;
using System.Collections.Generic;

namespace MetWorkingUserApplication.Contracts.Response
{
    public class UserInterestResponse
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public List<MetWorkingUserDomain.Entities.Interest> Interests { get; set; }
    }
}