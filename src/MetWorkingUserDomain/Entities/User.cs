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
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        
        public IList<UserInterests> Interest { get; set; }
    }   
}