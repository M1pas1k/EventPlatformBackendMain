using System.Text.Json.Serialization;

namespace WebApplication.Application.Payment
{
    public class PaymentConfirmation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("return_url")]
        public string ReturnUrl { get; set; }
    }
}
