using System.ComponentModel.DataAnnotations;

namespace MetWorkingUserAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public string Password { get; set; }
    }   
}