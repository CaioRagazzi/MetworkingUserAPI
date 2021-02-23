using System.Linq;
using FluentValidation;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.User.Validation
{
    public class CreateUserRequestValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserRequestValidation(IApplicationDbContext applicationDbContext)
        {            
            RuleFor(x => x.UserRequest.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UserRequest.Name)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.UserRequest.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.UserRequest.Email)
                .Must((createUserCommand, _) => {
                    var exists = applicationDbContext.Users.Where(
                        entity => entity.Email == createUserCommand.UserRequest.Email).ToList();

                    return !exists.Any();
                })
                .WithMessage("Already exists");
        }
    }
}