using System.Threading;
using System.Threading.Tasks;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserDomain.Entities;
using MetWorkingUserInfrastructure.Persistence.configurations;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserInfrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<UserInterests> UserInterests { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            this.Database.EnsureCreated();
            this.Database.MigrateAsync();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserEntityTypeConfiguration().Configure(builder.Entity<User>());
            new InterestEntityTypeConfiguration().Configure(builder.Entity<Interest>());
            new UserInterestEntityTypeConfiguration().Configure(builder.Entity<UserInterests>());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }   
}