using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Notifications.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Notifications.Handlers
{
    public class DeleteNotificationByIdHandler(IActions actions) : IRequestHandler<DeleteNotificationByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteNotificationByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Notification>(request.Id, cancellationToken);

        }
    }
}
