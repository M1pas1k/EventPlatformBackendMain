using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Tags
{
    public class TagUpdateDto : IMapWith<Tag>
    {
        public Guid Id { get; set; } 
        public string Title { get; set; } = string.Empty;
    }
}
