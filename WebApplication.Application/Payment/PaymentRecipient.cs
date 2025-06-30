using System.Text.Json.Serialization;

namespace WebApplication.Application.Payment
{
    public class PaymentRecipient
    {
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("gateway_id")]
        public string GatewayId { get; set; }
    }
}
