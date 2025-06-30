using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Events
{
    public class EventUpdateDto : IMapWith<Event>
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public uint? TotalTickets { get; set; }
        public uint? ReturnedTickets { get; set; }
        public DateTime? EndAt { get; set; }
        public DateTime? StartAt { get; set; }
        public string? Title { get; set; }
        public string? ImageId { get; set; }
        public string? Description { get; set; }
        public string? AdditionalRequirements { get; set; }
    }
}
