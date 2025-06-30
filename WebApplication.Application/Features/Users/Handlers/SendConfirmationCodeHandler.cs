using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Users.Commands;
using WebApplication.Application.Interfaces;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class SendConfirmationCodeHandler(IRandomCodeGeneration randomCode, IEmailSender emailSender, ICache cache) : IRequestHandler<SendConfirmationCodeCommand, Result>
    {
        public async Task<Result> Handle(SendConfirmationCodeCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                return Result.Failure("Email is required");

            string code = randomCode.GenerateRandomCode(6, true, true);

            await cache.StringSetAsync($"user_code:{request.Email}", code, cancellationToken, TimeSpan.FromMinutes(5));

            string subject = "Код подтверждения";
            string content = $"{code}";

            await emailSender.SendAsync(request.Email, subject, content, cancellationToken);

            return Result.Success();
        }
    }
}
