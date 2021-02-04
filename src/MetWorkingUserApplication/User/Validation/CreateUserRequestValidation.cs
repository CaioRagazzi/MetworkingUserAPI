using System.Linq;
using FluentValidation;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Validation
{
    public class CreateUserRequestValidation : AbstractValidator<CreateUserCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CreateUserRequestValidation(IApplicationDbContext _applicationDbContext)
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

            RuleFor(x => x.User.Email)
                .Must((createUserCommand, cancellation) => {
                    var exists = _applicationDbContext.Users.Where(
                        entity => entity.Email == createUserCommand.User.Email).ToList();

                    return !exists.Any();
                })
                .WithMessage("Already exists");
        }
    }
}