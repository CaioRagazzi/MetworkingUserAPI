using System.Threading.Tasks;
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

        public async Task<User> Create(User user)
        {
            _applicationDbContext.Users.Add(user);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _applicationDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _applicationDbContext.Users.FindAsync(id);

            return user;
        }
    }   
}