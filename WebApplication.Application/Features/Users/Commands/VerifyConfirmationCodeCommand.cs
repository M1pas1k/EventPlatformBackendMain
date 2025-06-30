using MediatR;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.Users.Commands
{
    public class VerifyConfirmationCodeCommand : IRequest<Result>
    {
        public string Code { get; set; }
        public string Email { get; set; }
    }
}
