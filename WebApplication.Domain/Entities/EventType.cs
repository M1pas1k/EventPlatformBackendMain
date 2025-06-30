using WebApplication.Domain.Common;

namespace WebApplication.Domain.Entities
{
    public class EventType : BaseEntity
    {

        public string Title { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;


        public ICollection<Event> Events { get; set; } = [];
    }
}
