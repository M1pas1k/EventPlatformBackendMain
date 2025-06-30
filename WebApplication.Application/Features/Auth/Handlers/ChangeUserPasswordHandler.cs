using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Auth.Commands;
using WebApplication.Application.Interfaces;

namespace WebApplication.Application.Features.Auth.Handlers
{
    public class ChangeUserPasswordHandler(IDatabaseContext context, IMapper mapper, IPasswordHasher hasher) : IRequestHandler<ChangeUserPasswordCommand, Result>
    {
        public async Task<Result> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var updated = await context.Users
                .Where(u => u.Id == request.UserId)
                .ExecuteUpdateAsync(p => p
                    .SetProperty(u => u.PasswordHash, hasher.Hash(request.Password))
                    .SetProperty(u => u.PasswordUpdatedAt, DateTime.UtcNow),
                cancellationToken);

            return updated == 0 ? Result.Failure("Password not updated", Status.BadRequest) : Result.Success();
        }
    }
}
