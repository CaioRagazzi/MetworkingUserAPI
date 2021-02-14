using System.Threading.Tasks;

namespace MetWorkingUserApplication.Interfaces.User
{
    public interface IUserService
    {
        Task<MetWorkingUserDomain.Entities.User> GetById(int id);
        
        Task<MetWorkingUserDomain.Entities.User> Create(MetWorkingUserDomain.Entities.User user);
    }   
}