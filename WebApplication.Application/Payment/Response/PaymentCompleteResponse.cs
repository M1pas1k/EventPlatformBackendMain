using System.Text.Json.Serialization;

namespace WebApplication.Application.Payment.Response
{
    public class PaymentCompleteResponse
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
