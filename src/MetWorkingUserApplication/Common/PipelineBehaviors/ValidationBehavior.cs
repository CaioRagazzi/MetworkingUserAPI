using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces.Slack;

namespace MetWorkingUserApplication.Common.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse: class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ISlackService _slackService;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ISlackService slackService)
        {
            _validators = validators;
            _slackService = slackService;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (!failures.Any())
            {
                var result = await next();
                if (result is not BaseResponse<UserResponse> userResponse) return result;
                if (userResponse.IsOk)
                {
                    await _slackService.PostToSlack($"User {userResponse.Data.Name} has been created!");
                }

                return result;
            }
            
            var responseType = typeof(TResponse);
            var resultType = responseType.GetGenericArguments()[0];
            var baseResponseType = typeof(BaseResponse<>).MakeGenericType(resultType);

            var invalidResponse = Activator.CreateInstance(baseResponseType, null, failures) as TResponse;

            return invalidResponse;

        }
    }
}