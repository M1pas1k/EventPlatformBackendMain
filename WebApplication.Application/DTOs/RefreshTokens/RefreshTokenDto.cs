using WebApplication.Application.Common.Mapping;

namespace WebApplication.Application.DTOs.RefreshTokens
{
    public class RefreshTokenDto : IMapWith<RefreshTokenDto>
    {
        public Guid Id { get; set; }
        public string Token { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
