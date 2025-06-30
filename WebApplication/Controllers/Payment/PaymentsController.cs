using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.DTOs.Purchases;
using WebApplication.Application.DTOs.UserTickets;
using WebApplication.Application.Features.Auth.Handlers;
using WebApplication.Application.Features.Events.Queries;
using WebApplication.Application.Features.Notifications.Commands;
using WebApplication.Application.Features.Purchases.Commands;
using WebApplication.Application.Features.Tickets.Commands;
using WebApplication.Application.Features.UserTickets.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Payment;
using WebApplication.Application.Payment.Response;
using WebApplication.Domain.Enums;

namespace WebApplication.API.Controllers.Payment
{
    [Authorize]
    [ApiController]
    [Route("/api/payment-confirm")]
    public class PaymentsController(IMediator mediator, IPaymentsProvider payments, ICache cache, IEmailSender email, IJobScheduler jobs) : ControllerApiBase
    {
        [HttpPost()]
        public async Task<IActionResult> ConfirmPayment([FromQuery] string orderId, CancellationToken ct)
        {
            var response = new PaymentCompleteResponse()
            {
                Id = orderId,
                Event = "payment.succeeded",
                Url = $"http://localhost:5091/api/purchases",
            };

            var payment = await cache.ObjectGetAsync<TicketPendingPayment>($"pending_payment:{response.Id}", ct);
            if (payment == null) return BadRequest(response.Id);
            await cache.RemoveAsync($"pending_payment:{response.Id}", ct);
            await mediator.Send(new DecreaseTicketAvailableCountCommand() { Id = payment.TicketId });

            var purchase = await mediator.Send(new CreatePurchaseCommand()
            {
                Entity = new PurchaseCreateDto
                {
                    Amount = payment.Amount,
                    BillUrl = "",
                    Status = PurchaseStatus.Success,
                    CustomerId = payment.UserId,
                    Date = DateTime.UtcNow,
                    ProductUrl = $"tickets/{payment.TicketId}",
                    Description = $"Покупка билета",
                }
            }, ct);
            if (purchase.IsFailure) return Problem($"Failed to process purchase of ticket");

            var userTicket = await mediator.Send(new CreateUserTicketCommand()
            {
                Entity = new UserTicketCreateDto
                {
                    UserId = payment.UserId,
                    TicketId = payment.TicketId
                }
            });
            if (userTicket.IsFailure) return Problem($"Failed to add user ticket");

            var eventResult = await mediator.Send(new GetEventByIdQuery() { Id = payment.EventId }, ct);
            var userResult = await mediator.Send(new GetIdentityByIdQuery() { Id = payment.UserId }, ct);
            var event_ = eventResult.Value!;
            var user = userResult.Value!;

            var notificationCreate = new NotificationCreateDto
            {
                UserId = user.Id,
                Subject = "Покупка билета",
                Content = $"Покупка билета {payment.TicketId} прошла успешно.",
                Type = NotificationType.Info
            };

            var createResult = await mediator.Send(new CreateNotificationCommand { Entity = notificationCreate }, ct);
            if (createResult.IsFailure) return ToActionResult(createResult);
            var notificationDto = createResult.Value!;
            await mediator.Send(new SendNotificationCommand { Notification = notificationDto }, ct);

            await email.SendAsync(user.Email, notificationCreate.Subject, notificationCreate.Content, ct);
            await jobs.ScheduleEventEmailReminder(event_.StartAt.AddHours(-24), user.Email, payment.EventId, ct);

            return ToActionResult(purchase);
        }
    }
}
