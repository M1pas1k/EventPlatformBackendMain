using WebApplication.Application.Common.Mapping;
using WebApplication.Application.DTOs.EventMoods;
using WebApplication.Application.DTOs.EventTypes;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Users
{
    public class UserEventDto : IMapWith<Event>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartAt { get; set; }
        public string? ImageId { get; set; }
        public EventTypeDto EventType { get; set; } = null!;
        public EventMoodDto EventMood { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
