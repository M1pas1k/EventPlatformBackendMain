using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.EventTypes
{
    public class EventTypeCreateDto : IMapWith<EventType>
    {
        public string Title { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
    }
}
