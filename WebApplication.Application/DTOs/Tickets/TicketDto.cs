using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Tickets
{
    public class TicketDto : IMapWith<Ticket>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public uint AvailableCount { get; set; }
        public Guid EventId { get; set; }
    }
}
