using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.API.Extensions;
using WebApplication.Application.Features.Purchases.Queries;
using WebApplication.Application.Features.Tickets.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Payment;
using WebApplication.Application.Payment.Request;
using WebApplication.Domain.Entities;

namespace WebApplication.API.Controllers.Customer
{
    [Authorize]
    //[Tags("Customer")]
    [ApiController]
    [Route("/api/purchases")]
    public class PurchaseController(IMediator mediator, IPaymentsProvider payments, ICache cache) : ControllerApiBase
    {
        [HttpPost("ticket")]
        public async Task<IActionResult> PurchaseTicket([FromQuery] Guid ticketId, CancellationToken ct)
        {
            var ticketResult = await mediator.Send(new GetTicketIfAvailableQuery() { Id = ticketId }, ct);
            if (ticketResult.IsFailure)
            {
                return ToActionResult(ticketResult);
            }
            if (ticketResult.Value.AvailableCount == 0)
            {
                return BadRequest("No available tickets left");
            }

            var ticket = ticketResult.Value;
            var payment = new PaymentCreate
            {
                Amount = new PaymentAmount
                {
                    Value = ticket.Price,
                    Currency = "RUB",
                },
                Capture = true,
                Description = $"Покупка билета '{ticket.Title}'",
                Confirmation = new PaymentConfirmation
                {
                    Type = "redirect",
                    ReturnUrl = "http://localhost:7104/api/payment-confirm"
                }
            };

            var createResponse = await payments.ProducePayment(payment);
            if (createResponse.Status != PaymentStatus.Pending)
            {
                BadRequest("Something went wrong");
            }

            var ticketPendingPayment = new TicketPendingPayment
            {
                Id = createResponse.Id,
                Amount = createResponse.Amount.Value,
                Status = createResponse.Status,
                TicketId = ticketId,
                Confirmation = createResponse.Confirmation,
                UserId = User.Id(),
                EventId = ticket.EventId,
            };

            await cache.ObjectSetAsync($"pending_payment:{createResponse.Id}", ticketPendingPayment, ct);

            return Ok(createResponse.Confirmation.ReturnUrl);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetPurchaseByIdQuery() { Id = id }, ct));
        }
    }
}
