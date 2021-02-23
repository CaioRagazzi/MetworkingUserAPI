using System.Linq;
using FluentValidation;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Validation
{
    public class UpdateUserRequestValidation : AbstractValidator<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        
        public UpdateUserRequestValidation(IApplicationDbContext _applicationDbContext)
        {            
            RuleFor(x => x.UserUpdateRequest.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UserUpdateRequest.Name)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.UserUpdateRequest.Email)
                .Must((createUserCommand, cancellation) => {
                    var exists = _applicationDbContext.Users.Where(
                        entity => entity.Email == createUserCommand.UserUpdateRequest.Email && entity.Id != createUserCommand.UserUpdateRequest.Id).ToList();

                    return !exists.Any();
                })
                .WithMessage("Already exists");
        }
        
    }
}