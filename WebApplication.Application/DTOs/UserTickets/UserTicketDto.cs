using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.UserTickets
{
    public class UserTicketDto : IMapWith<UserTicket>
    {
        public Guid Id { get; set; }
        public string TicketTitle { get; set; } = null!;
        public string TicketStatus { get; set; } = null!;
    }
}
