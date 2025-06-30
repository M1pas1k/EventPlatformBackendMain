using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.EventMoods
{
    public class EventMoodDto : IMapWith<EventMood>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
