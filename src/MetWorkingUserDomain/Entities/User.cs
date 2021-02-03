using System;
using System.ComponentModel.DataAnnotations;
using MetWorkingUserDomain.Interfaces;

namespace MetWorkingUserDomain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
    }   
}