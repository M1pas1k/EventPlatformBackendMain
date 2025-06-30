using MediatR;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.Users.Commands
{
    public class SendConfirmationCodeCommand : IRequest<Result>
    {
        public string Email { get; set; }
    }
}
