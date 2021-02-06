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
                .Must((createUserCommand, cancellation) => {
                    var exists = _applicationDbContext.Users.Where(
                        entity => entity.Email == createUserCommand.UserRequest.Email).ToList();

                    return !exists.Any();
                })
                .WithMessage("Already exists");
        }
    }
}