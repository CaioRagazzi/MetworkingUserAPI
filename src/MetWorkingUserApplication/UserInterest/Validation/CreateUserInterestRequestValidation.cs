using System.Linq;
using FluentValidation;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.UserInterest.Commands;

namespace MetWorkingUserApplication.UserInterest.Validation
{
    public class CreateUserInterestRequestValidation : AbstractValidator<CreateUserInterestCommand>
    {

        public CreateUserInterestRequestValidation(IApplicationDbContext applicationDbContext)
        {
            RuleFor(x => x.InterestId)
                .Must((createUserCommand, cancellation) => {
                    var exists = applicationDbContext.UserInterests.Where(
                        entity => entity.InterestId == createUserCommand.InterestId && entity.UserId == createUserCommand.UserId).ToList();

                    return !exists.Any();
                })
                .WithMessage("Interest has already been added to the user!");
        }
    }
}