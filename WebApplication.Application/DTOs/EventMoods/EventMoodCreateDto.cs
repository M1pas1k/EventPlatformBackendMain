using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.EventMoods
{
    public class EventMoodCreateDto : IMapWith<EventMood>
    {
        public string Title { get; set; } = string.Empty;
    }
}
