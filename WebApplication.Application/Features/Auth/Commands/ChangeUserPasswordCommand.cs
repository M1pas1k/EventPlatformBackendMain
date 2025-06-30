using MediatR;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.Auth.Commands
{
    public class ChangeUserPasswordCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }

        public string? Password { get; set; }

    }
}
