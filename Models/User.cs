using System.ComponentModel.DataAnnotations;

namespace MetWorkingUserAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
    }   
}