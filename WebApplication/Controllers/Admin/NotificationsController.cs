using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.Features.Notifications.Commands;

namespace WebApplication.API.Controllers.Admin
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/notifications")]
    public class NotificationsController(IMediator mediator) : ControllerApiBase
    {
        [HttpPost]
        public async Task<IActionResult> SendTest(NotificationCreateDto notification, IMapper mapper, CancellationToken ct)
        {
            var createResult = await mediator.Send(new CreateNotificationCommand { Entity = notification }, ct);
            if (createResult.IsFailure) return ToActionResult(createResult);

            var notificationDto = createResult.Value!;
            await mediator.Send(new SendNotificationCommand { Notification = notificationDto }, ct);

            return Ok();
        }
    }
}
