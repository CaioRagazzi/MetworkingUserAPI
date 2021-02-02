using MetWorkingUserDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetWorkingUserInfrastructure.Context
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.Password)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}