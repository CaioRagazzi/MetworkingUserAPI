using MetWorkingUserDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetWorkingUserInfrastructure.Persistence.configurations
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

            builder
                .Property(u => u.Image)
                .HasColumnType("BLOB");

            builder
                .Property(u => u.Description)
                .HasMaxLength(255);

            builder
                .Property(u => u.Company)
                .HasMaxLength(255);

            builder
                .Property(u => u.Role)
                .HasMaxLength(255);
        }
    }
}