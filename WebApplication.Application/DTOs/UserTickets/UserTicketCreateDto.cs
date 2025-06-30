using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.UserTickets
{
    public class UserTicketCreateDto : IMapWith<UserTicket>
    {
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
    }
}
