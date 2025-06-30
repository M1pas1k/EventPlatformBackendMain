using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Tickets
{
    public class TicketUpdateDto : IMapWith<Ticket>
    {
        public string? Title { get; set; }
        public decimal? Price { get; set; }
    }
}
