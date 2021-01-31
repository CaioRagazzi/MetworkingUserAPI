using MetWorkingUserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=172.17.0.2;database=metworkingusers;user=root;password=password");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserEntityTypeConfiguration().Configure(builder.Entity<User>());
        }
    }   
}