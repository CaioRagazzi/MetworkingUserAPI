using FluentValidation;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.User.Commands;

namespace MetWorkingUserApplication.User.Validation
{
    public class AuthenticateUserRequestValidation : AbstractValidator<AuthenticateUserCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AuthenticateUserRequestValidation(IApplicationDbContext _applicationDbContext)
        {
            RuleFor(x => x.AuthenticateUserRequest.UserEmail)
                .NotEmpty()
                .EmailAddress();
            
            RuleFor(x => x.AuthenticateUserRequest.Password)
                .NotEmpty()
                .MinimumLength(6);

        }
    }
}