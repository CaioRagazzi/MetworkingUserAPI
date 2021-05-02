using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetWorkingUserDomain.Models;

namespace MetWorkingUserDomain.Interfaces
{
    public interface IGeoService
    {
        Task<List<Timeline>> GetUserTimeLine(Guid userId);
    }
}