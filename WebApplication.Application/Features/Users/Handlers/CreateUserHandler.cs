using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Users.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class CreateUserHandler(IPasswordHasher passwordHasher, IActions actions)
        : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<User, UserDto>(request.Entity, cancellationToken,
                async (user, context) =>
                {
                    user.PasswordHash = passwordHasher.Hash(request.Entity.Password);

                    var roles = request.Entity.RoleIds
                        .Select(id => new Role() { Id = id })
                        .ToList();
                    context.Roles.AttachRange(roles);
                    user.Roles = roles;
                });
        }
    }
}
