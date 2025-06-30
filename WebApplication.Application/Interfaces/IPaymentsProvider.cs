using WebApplication.Application.Payment.Request;
using WebApplication.Application.Payment.Response;

namespace WebApplication.Application.Interfaces
{
    public interface IPaymentsProvider
    {
        PaymentCreateResponse GenerateTestPaymentResponse(PaymentCreate payment);
        Task<PaymentCreateResponse> ProducePayment(PaymentCreate payment);
        Task ValidateWebhook(PaymentCompleteResponse response);
    }
}
