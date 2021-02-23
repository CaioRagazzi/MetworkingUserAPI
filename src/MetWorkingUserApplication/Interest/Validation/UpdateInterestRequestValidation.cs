using FluentValidation;
using MetWorkingUserApplication.Interest.Commands;

namespace MetWorkingUserApplication.Interest.Validation
{
    public class UpdateInterestRequestValidation : AbstractValidator<UpdateInterestCommand>
    {
        public UpdateInterestRequestValidation()
        {
            RuleFor(x => x.UpdateInterestRequest.Name)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.UpdateInterestRequest.Description)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}