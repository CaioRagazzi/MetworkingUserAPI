using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Contracts.Request;
using NUnit.Framework;

namespace MetWorkingUser.Application.Integration.Tests.User.Commands
{
    using static Testing;
    public class CreateUserCommandTest : TestBase
    {
        [Test]
        public async Task ShouldCreateUser()
        {
            var createUserRequest = new CreateUserRequest
            {
                Email = "ca.ragazzi@gmail.com",
                Name = "Caio Eduardo Ragazzi Gemignani",
                Password = "123456"
            };
            
            var command = new CreateUserCommand(createUserRequest);
            
            var result = await SendAsync(command);

            result.Data.Email.Should().BeOfType(typeof(string));
            result.Data.Email.Should().Be(createUserRequest.Email);
            result.Data.Id.Should().NotBeEmpty();
            result.Data.Name.Should().BeOfType(typeof(string));
            result.Data.Name.Should().Be(createUserRequest.Name);
        }

        [Test]
        public async Task ShoudlReturnEmailInvalidError()
        {
            var createUserRequest = new CreateUserRequest
            {
                Email = "ca.ragazzigmail.com",
                Name = "Caio Eduardo Ragazzi Gemignani",
                Password = "123456"
            };
            
            var command = new CreateUserCommand(createUserRequest);
            var result = await SendAsync(command);

            result.Errors.Should().NotBe(null);
            result.Errors.data.Should().Contain("'User Request. Email' is not a valid email address.");
            result.IsOk.Should().BeFalse();
            result.Data.Should().BeNull();
        }
        
        [Test]
        public async Task ShoudlReturnEmailEmptyError()
        {
            var createUserRequest = new CreateUserRequest
            {
                Email = "",
                Name = "Caio Eduardo Ragazzi Gemignani",
                Password = "123456"
            };
            
            var command = new CreateUserCommand(createUserRequest);
            var result = await SendAsync(command);

            result.Errors.Should().NotBe(null);
            result.Errors.data.Should().Contain("'User Request. Email' must not be empty.");
            result.Errors.data.Should().Contain("'User Request. Email' is not a valid email address.");
            result.IsOk.Should().BeFalse();
            result.Data.Should().BeNull();
        }
        
        [Test]
        [TestCase("123", "ca.ragazzi2@gmail.com")]
        public async Task ShoudlReturnPasswordMinLengthError(string password, string email)
        {
            var createUserRequest = new CreateUserRequest
            {
                Email = email,
                Name = "Caio Eduardo Ragazzi Gemignani",
                Password = password
            };
            
            var command = new CreateUserCommand(createUserRequest);
            var result = await SendAsync(command);

            result.Errors.Should().NotBe(null);
            result.Errors.data.Should().Contain($"The length of 'User Request. Password' must be at least 6 characters. You entered {password.Length} characters.");
            result.IsOk.Should().BeFalse();
            result.Data.Should().BeNull();
        }
        
        [Test]
        public async Task ShoudlReturnPasswordEmptyError()
        {
            var createUserRequest = new CreateUserRequest
            {
                Email = "ca.ragazzi@gmail.com",
                Name = "Caio Eduardo Ragazzi Gemignani",
                Password = ""
            };
            
            var command = new CreateUserCommand(createUserRequest);
            var result = await SendAsync(command);

            result.Errors.Should().NotBe(null);
            result.Errors.data.Should().Contain("'User Request. Password' must not be empty.");
            result.Errors.data.Should().Contain("The length of 'User Request. Password' must be at least 6 characters. You entered 0 characters.");
            result.IsOk.Should().BeFalse();
            result.Data.Should().BeNull();
        }
        
        [Test]
        public async Task ShoudlReturnUserAlreadyExistsError()
        {
            var createUserRequest = new CreateUserRequest
            {
                Email = "ca.ragazzi@gmail.com",
                Name = "Caio Eduardo Ragazzi Gemignani",
                Password = "123123"
            };
            var command = new CreateUserCommand(createUserRequest);
            
            await SendAsync(command);
            var result = await SendAsync(command);

            result.Errors.Should().NotBe(null);
            result.Errors.data.Should().Contain("Already exists");
            result.IsOk.Should().BeFalse();
            result.Data.Should().BeNull();
        }
    }
}