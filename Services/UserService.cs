using System.Linq;
using MetWorkingUserAPI.Context;
using MetWorkingUserAPI.Interfaces;
using MetWorkingUserAPI.Models;

namespace MetWorkingUserAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public void Create(User user)
        {
            _applicationDbContext.Users.Add(user);
            _applicationDbContext.SaveChanges();
        }

        public User GetById(int id)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(u => u.UserId == id);

            return user;
        }
    }   
}