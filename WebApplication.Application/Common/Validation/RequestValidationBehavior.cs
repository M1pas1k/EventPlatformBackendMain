using FluentValidation;
using MediatR;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Common.Validation
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators) =>
            _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            if (failures.Count != 0)
            {
                var type = typeof(TResponse);

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var innerType = typeof(TResponse).GetGenericArguments()[0];

                    var failureMethod = typeof(Result)
                        .GetMethod("Failure", 1, [typeof(string), typeof(Status)])!
                        .MakeGenericMethod(innerType);

                    if (failureMethod != null)
                    {
                        var res = failureMethod.Invoke(null, [string.Join(",\n", failures), Status.Validation])!;
                        return (TResponse)res;
                    }
                }
                else if (type == typeof(Result))
                {
                    return (TResponse)(object)Result.Failure(string.Join(",\n", failures), Status.Validation);
                }

                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
