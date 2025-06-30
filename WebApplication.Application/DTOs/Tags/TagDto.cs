using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Tags
{
    public class TagDto : IMapWith<Tag>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
