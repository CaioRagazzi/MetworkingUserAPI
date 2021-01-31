using MetWorkingUserAPI.Models;

namespace MetWorkingUserAPI.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        void Create(User user);
    }   
}