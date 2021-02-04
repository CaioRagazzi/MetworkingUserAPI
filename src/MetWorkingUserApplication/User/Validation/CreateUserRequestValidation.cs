using FluentValidation;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Contracts.Request;

namespace MetWorkingUserApplication.Validation
{
    public class CreateUserRequestValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserRequestValidation()
        {
            RuleFor(x => x.User.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.User.Name)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.User.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}