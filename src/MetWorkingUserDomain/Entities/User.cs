using System;
using System.Collections.Generic;
using MetWorkingUserDomain.Interfaces;

namespace MetWorkingUserDomain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<UserInterests> Interest { get; set; }
    }   
}