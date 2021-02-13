using MetWorkingUserDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MetWorkingUserApplication.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<MetWorkingUserDomain.Entities.Interest> Interest { get; set; }
        DbSet<UserInterests> UserInterests { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}