using WebApplication.Domain.Common;

namespace WebApplication.Domain.Entities
{
    public class Ticket : BaseEntity
    {

        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public uint AvailableCount { get; set; }

        public Guid EventId { get; set; }

        public Event Event { get; set; } = null!;

        public ICollection<UserTicket> UserTickets { get; set; } = [];
    }
}
