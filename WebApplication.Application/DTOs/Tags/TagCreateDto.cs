using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Tags
{
    public class TagCreateDto : IMapWith<Tag>
    {
        public string? Title { get; set; }
    }
}
