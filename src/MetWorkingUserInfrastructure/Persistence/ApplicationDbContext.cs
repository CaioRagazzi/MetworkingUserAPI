using System.Threading;
using System.Threading.Tasks;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserDomain.Entities;
using MetWorkingUserInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserInfrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserEntityTypeConfiguration().Configure(builder.Entity<User>());
            new InterestEntityTypeConfiguration().Configure(builder.Entity<Interest>());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }   
}