using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.EventTypes
{
    public class EventTypeUpdateDto : IMapWith<EventType>
    {
        public string? Title { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
