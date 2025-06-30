using WebApplication.Domain.Common;

namespace WebApplication.Domain.Entities
{
    public class Role : BaseEntity
    {

        public string Name { get; set; } = string.Empty;

        public bool isPublic { get; set; }

        public ICollection<User> Users { get; set; } = [];
    }
}
