using MetWorkingUserDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetWorkingUserInfrastructure.Context
{
    public class InterestEntityTypeConfiguration : IEntityTypeConfiguration<Interest>
    {
        public void Configure(EntityTypeBuilder<Interest> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}