using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using FluentValidation.Results;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Common.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : BaseResponse<string>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (failures.Any())
            {
                var teste = Errors(failures);
                return teste;
            }

            return next();
        }
        
        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new BaseResponse<string>();

            foreach (var failure in failures)
            {
                response.Errors.Add(failure.ErrorMessage);
                response.IsOk = false;
                response.Data = "";
            }
            return Task.FromResult(response as TResponse);
        }
    }
}