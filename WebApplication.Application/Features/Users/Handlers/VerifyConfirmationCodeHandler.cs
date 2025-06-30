using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Users.Commands;
using WebApplication.Application.Interfaces;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class VerifyConfirmationCodeHandler(ICache cache) : IRequestHandler<VerifyConfirmationCodeCommand, Result>
    {
        public async Task<Result> Handle(VerifyConfirmationCodeCommand request, CancellationToken cancellationToken)
        {
            var storedCode = await cache.StringGetAsync($"user_code:{request.Email}", cancellationToken);
            return storedCode == request.Code ? Result.Success() : Result.Failure("Code not found", Status.NotFound);
        }
    }
}
