using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Common.Exceptions;
using MetWorkingUserApplication.Contracts.Request;
using NUnit.Framework;

namespace MetWorkingUser.Application.Integration.Tests.User.Commands
{
    using static Testing;
    public class UpdateUserCommandTest : TestBase
    {
        [Test]
        public async Task ShouldUpdateUser()
        {
            var guid = Guid.NewGuid();
            var user = new MetWorkingUserDomain.Entities.User
            {
                Email = "ca.ragazzi@gmail.com",
                Id = guid,
                Name = "Caio Eduardo Ragazzi",
                Password = "123456"
            };
            
            await AddAsync(user);
            
            var updateUserRequest = new UpdateUserRequest()
            {
                Email = "ca.ragazziupdated@gmail.com",
                Name = "Caio Eduardo Ragazzi Gemignani Updated",
                Id = guid
            };
            
            var command = new UpdateUserCommand(updateUserRequest);
            
            var result = await SendAsync(command);
        
            var updatedUser = await FindAsync<MetWorkingUserDomain.Entities.User>(user.Id);
        
            updatedUser.Email.Should().BeOfType(typeof(string));
            updatedUser.Email.Should().Be(updateUserRequest.Email);
            updatedUser.Id.Should().NotBeEmpty();
            updatedUser.Id.Should().Be(guid);
            updatedUser.Name.Should().BeOfType(typeof(string));
            updatedUser.Name.Should().Be(updateUserRequest.Name);
        }
        
        [Test]
        [TestCase("ca.ragazzigmail.com", "Caio Ragazzi Updated", "Validation failed: \n -- UserUpdateRequest.Email: 'User Update Request. Email' is not a valid email address.")]
        [TestCase("", "Caio Ragazzi Updated", "Validation failed: \n -- UserUpdateRequest.Email: 'User Update Request. Email' must not be empty.\n -- UserUpdateRequest.Email: 'User Update Request. Email' is not a valid email address.")]
        [TestCase("ca.ragazziupdated@gmail.com", "Ca", "Validation failed: \n -- UserUpdateRequest.Name: The length of 'User Update Request. Name' must be at least 3 characters. You entered 2 characters.")]
        [TestCase("ca.ragazzi@gmail.com", "Caio Ragazzi Updated", "Validation failed: \n -- UserUpdateRequest.Email: Already exists")]
        public async Task ShouldReturnError(string email, string name, string errorMessage)
        {
            var guid = Guid.NewGuid();
            var user = new MetWorkingUserDomain.Entities.User
            {
                Email = "ca.ragazzi@gmail.com",
                Id = guid,
                Name = "Caio Ragazzi",
                Password = "123456"
            };
            
            await AddAsync(user);
            
            var updateUserRequest = new UpdateUserRequest()
            {
                Email = email,
                Name = name,
                Id = guid
            };
            
            var command = new UpdateUserCommand(updateUserRequest);
        
            FluentActions.Invoking(() =>
                    SendAsync(command)).Should().Throw<ValidationException>()
                .WithMessage(errorMessage);
        }
        
        [Test]
        public async Task ShouldReturnNotFoundError()
        {
            var guid = Guid.NewGuid();
            var user = new MetWorkingUserDomain.Entities.User
            {
                Email = "ca.ragazzi@gmail.com",
                Id = guid,
                Name = "Caio Ragazzi",
                Password = "123456"
            };
            
            await AddAsync(user);
            
            var updateUserRequest = new UpdateUserRequest()
            {
                Email = "ca.ragazziupdated@gmail.com",
                Name = "Caio Ragazzi Updated",
                Id = Guid.NewGuid()
            };
            
            var command = new UpdateUserCommand(updateUserRequest);
        
            FluentActions.Invoking(() =>
                    SendAsync(command)).Should().Throw<NotFoundException>()
                .WithMessage("Exception of type 'MetWorkingUserApplication.Common.Exceptions.NotFoundException' was thrown.");
        }
    }
}