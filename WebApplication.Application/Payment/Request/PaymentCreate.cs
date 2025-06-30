using System.Text.Json.Serialization;

namespace WebApplication.Application.Payment.Request
{
    public class PaymentCreate
    {
        [JsonPropertyName("amount")]
        public PaymentAmount Amount { get; set; }

        [JsonPropertyName("capture")]
        public bool Capture { get; set; }

        [JsonPropertyName("confirmation")]
        public PaymentConfirmation Confirmation { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
