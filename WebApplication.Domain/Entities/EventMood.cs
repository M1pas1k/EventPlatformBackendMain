using WebApplication.Domain.Common;

namespace WebApplication.Domain.Entities
{
    public class EventMood : BaseEntity
    {

        public string Title { get; set; } = string.Empty;


        public ICollection<Event> Events { get; set; } = [];
    }
}
