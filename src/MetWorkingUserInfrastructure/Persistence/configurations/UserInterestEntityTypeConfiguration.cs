using MetWorkingUserDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetWorkingUserInfrastructure.Persistence.configurations
{
    public class UserInterestEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<UserInterests> builder)
        {
            builder.HasKey(usi => new {usi.UserId, usi.InterestId});

            builder
                .HasOne<User>(usr => usr.User)
                .WithMany(usi => usi.Interest)
                .HasForeignKey(usi => usi.UserId);
        }
    }
}