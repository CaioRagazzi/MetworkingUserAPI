using FluentValidation;
using MetWorkingUserApplication.Interest.Commands;

namespace MetWorkingUserApplication.Interest.Validation
{
    public class CreateInterestRequestValidation: AbstractValidator<CreateInterestCommand>
    {
        public CreateInterestRequestValidation()
        {
            RuleFor(x => x.CreateInterestRequest.Name)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.CreateInterestRequest.Description)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}