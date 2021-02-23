using System;
using MetWorkingUserDomain.Interfaces;

namespace MetWorkingUserDomain.Entities
{
    public class Interest : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}