using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using FluentValidation.Results;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Common.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse: class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (failures.Any())
            {
                var responseType = typeof(TResponse);
                var resultType = responseType.GetGenericArguments()[0];
                var baseResponseType = typeof(BaseResponse<>).MakeGenericType(resultType);

                var invalidResponse = Activator.CreateInstance(baseResponseType, null, failures) as TResponse;

                return invalidResponse;
            }

            return await next();
        }
    }
}