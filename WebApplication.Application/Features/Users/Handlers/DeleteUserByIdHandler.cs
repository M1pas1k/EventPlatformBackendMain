using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Users.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class DeleteUserByIdHandler(IActions actions) : IRequestHandler<DeleteUserByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<User>(request.Id, cancellationToken);
        }
    }
}
