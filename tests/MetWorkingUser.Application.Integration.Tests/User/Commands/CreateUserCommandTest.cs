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

            result.Email.Should().BeOfType(typeof(string));
            result.Email.Should().Be(createUserRequest.Email);
            result.Id.Should().NotBeEmpty();
            result.Name.Should().BeOfType(typeof(string));
            result.Name.Should().Be(createUserRequest.Name);
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

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>()
                .WithMessage("Validation failed: \n -- UserRequest.Email: 'User Request. Email' is not a valid email address.");
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

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>()
                    .WithMessage("Validation failed: \n -- UserRequest.Email: 'User Request. Email' must not be empty.\n -- UserRequest.Email: 'User Request. Email' is not a valid email address.");
        }
        
        [Test]
        [TestCase("123", "ca.ragazzi2@gmail.com")]
        [TestCase("1234", "ca.ragazzi1@gmail.com")]
        [TestCase("12345", "ca.ragazzi3@gmail.com")]
        public async Task ShoudlReturnPasswordMinLengthError(string password, string email)
        {
            var createUserRequest = new CreateUserRequest
            {
                Email = email,
                Name = "Caio Eduardo Ragazzi Gemignani",
                Password = password
            };
            
            var command = new CreateUserCommand(createUserRequest);

            FluentActions.Invoking(() =>
                    SendAsync(command)).Should().Throw<ValidationException>()
                .WithMessage($"Validation failed: \n -- UserRequest.Password: The length of 'User Request. Password' must be at least 6 characters. You entered {password.Length} characters.");
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

            FluentActions.Invoking(() =>
                    SendAsync(command)).Should().Throw<ValidationException>()
                .WithMessage("Validation failed: \n -- UserRequest.Password: 'User Request. Password' must not be empty.\n -- UserRequest.Password: The length of 'User Request. Password' must be at least 6 characters. You entered 0 characters.");
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

            FluentActions.Invoking(() =>
                    SendAsync(command)).Should().Throw<ValidationException>()
                .WithMessage("Validation failed: \n -- UserRequest.Email: Already exists");
        }
    }
}