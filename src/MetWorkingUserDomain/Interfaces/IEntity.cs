using System;
using System.Collections.Generic;
using System.Text;

namespace MetWorkingUserDomain.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}