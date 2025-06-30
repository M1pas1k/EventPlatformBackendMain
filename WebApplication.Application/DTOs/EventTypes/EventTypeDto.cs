using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;


namespace WebApplication.Application.DTOs.EventTypes
{
    public class EventTypeDto : IMapWith<EventType>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
