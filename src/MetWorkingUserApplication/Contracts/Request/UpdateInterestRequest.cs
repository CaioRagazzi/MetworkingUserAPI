using System;

namespace MetWorkingUserApplication.Contracts.Request
{
    public class UpdateInterestRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}