using WebApplication.Domain.Common;
using WebApplication.Domain.Enums;

namespace WebApplication.Domain.Entities
{
    public class UserTicket : BaseEntity
    {

        public UserTicketStatus TicketStatus { get; set; } = UserTicketStatus.Active;

        public Guid TicketId { get; set; }

        public Ticket Ticket { get; set; } = null!;

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
