using System.Text.Json.Serialization;

namespace WebApplication.Application.Payment.Response
{
    public class PaymentCreateResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("paid")]
        public bool Paid { get; set; }

        [JsonPropertyName("amount")]
        public PaymentAmount Amount { get; set; }

        [JsonPropertyName("confirmation")]
        public PaymentConfirmation Confirmation { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonPropertyName("recipient")]
        public PaymentRecipient Recipient { get; set; }

        [JsonPropertyName("refundable")]
        public bool Refundable { get; set; }

        [JsonPropertyName("test")]
        public bool Test { get; set; }
    }
}
