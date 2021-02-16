using System;
using System.Threading.Tasks;
using FluentAssertions;
using MetWorkingUserApplication.Queries;
using NUnit.Framework;

namespace MetWorkingUser.Application.Integration.Tests.User.Queries
{
    using static Testing;
    public class GetUserByIdQueryTests: TestBase
    {
        [Test]
        public async Task ShouldReturnUserById()
        {
            var guid = Guid.NewGuid();
            await AddAsync(new MetWorkingUserDomain.Entities.User
            {
                Email = "ca.ragazzi@gmail.com",
                Id = guid,
                Name = "Caio Eduardo Ragazzi",
                Password = "123456"
            });
            var query = new GetUserByIdQuery(guid);

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Data.Email.Should().BeOfType(typeof(string));
            result.Data.Email.Should().Be("ca.ragazzi@gmail.com");
            result.Data.Id.Should().Be(guid);
            result.Data.Name.Should().BeOfType(typeof(string));
            result.Data.Name.Should().Be("Caio Eduardo Ragazzi");
        } 
        
    }
}