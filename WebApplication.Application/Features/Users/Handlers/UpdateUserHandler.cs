using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Users.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class UpdateUserHandler(IActions actions, IPasswordHasher hasher) : IRequestHandler<UpdateUserCommand, Result<UserDto>>
    {
        public async Task<Result<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<User, UserDto>(request.Id, request.User, cancellationToken, (user) =>
            {
                user.LastUpdatedAt = DateTime.UtcNow;
            });
        }
    }
}
