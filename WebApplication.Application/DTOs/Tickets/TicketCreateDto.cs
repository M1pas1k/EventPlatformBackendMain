using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Tickets
{
    public class TicketCreateDto : IMapWith<Ticket>
    {
        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public uint AvailableCount { get; set; }
    }
}
