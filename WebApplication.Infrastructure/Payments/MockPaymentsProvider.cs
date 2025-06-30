using WebApplication.Application.Interfaces;
using WebApplication.Application.Payment;
using WebApplication.Application.Payment.Request;
using WebApplication.Application.Payment.Response;

namespace WebApplication.Infrastructure.Payments
{
    public class MockPaymentsProvider : IPaymentsProvider
    {

        public async Task<PaymentCreateResponse> ProducePayment(PaymentCreate payment)
        {
            await Task.Delay(1000);
            var orderId = Guid.NewGuid().ToString();
            var response = GenerateTestPaymentResponse(payment);

            return response;
        }

        public async Task ValidateWebhook(PaymentCompleteResponse response)
        {

        }

        public PaymentCreateResponse GenerateTestPaymentResponse(PaymentCreate payment)
        {
            var orderId = Guid.NewGuid().ToString();
            return new PaymentCreateResponse
            {
                Id = orderId,
                Amount = payment.Amount,
                Confirmation = new PaymentConfirmation
                {
                    Type = "redirect",
                    ReturnUrl = $"http://localhost:5071/api/payment-confirm?orderId={orderId}"
                },
                CreatedAt = DateTime.UtcNow,
                Description = payment.Description,
                Paid = false,
                Recipient = new PaymentRecipient
                {
                    AccountId = Guid.NewGuid().ToString(),
                    GatewayId = Guid.NewGuid().ToString(),
                },
                Status = PaymentStatus.Pending,
                Refundable = false,
                Test = true,
                Metadata = { }
            };
        }
    }
}
