using System.Threading;
using System.Threading.Tasks;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserInfrastructure.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=172.17.0.2;database=metworkingusers;user=root;password=password",
                b => b.MigrationsAssembly("MetWorkingUserPresentation")
            );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserEntityTypeConfiguration().Configure(builder.Entity<User>());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }   
}