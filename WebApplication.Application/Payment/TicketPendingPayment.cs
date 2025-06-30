namespace WebApplication.Application.Payment
{
    public class TicketPendingPayment
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; }

        public Guid UserId { get; set; }

        public Guid TicketId { get; set; }

        public Guid EventId { get; set; }

        public PaymentConfirmation Confirmation { get; set; }
    }
}
