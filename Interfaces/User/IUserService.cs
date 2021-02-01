using System.Threading.Tasks;
using MetWorkingUserAPI.Models;

namespace MetWorkingUserAPI.Interfaces
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<User> Create(User user);
    }   
}