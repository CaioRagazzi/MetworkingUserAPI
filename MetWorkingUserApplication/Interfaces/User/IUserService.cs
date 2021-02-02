using System.Threading.Tasks;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Interfaces
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<User> Create(User user);
    }   
}