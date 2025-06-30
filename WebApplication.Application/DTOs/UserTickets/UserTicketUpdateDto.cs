using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;

namespace WebApplication.Application.DTOs.UserTickets
{
    public class UserTicketUpdateDto : IMapWith<UserTicket>
    {
        public UserTicketStatus? TicketStatus { get; set; }

    }
}
