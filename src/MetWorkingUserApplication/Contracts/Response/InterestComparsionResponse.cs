using System;
using System.Collections.Generic;

namespace MetWorkingUserApplication.Contracts.Response
{
    public class InterestComparsionResponse
    {
        public InterestComparsionResponse()
        {
            IdAmigos = new List<Guid>();
        }
        public List<Guid> IdAmigos { get; set; }
    }
}
