using System;
using System.Collections.Generic;
using System.Text;

namespace MetWorkingUserDomain.Entities
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}