using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;


namespace WebApplication.Application.DTOs.Purchases
{
    public class PurchaseUpdateDto : IMapWith<Purchase>
    {
        public string? ProductUrl { get; set; } = null!;
        public string? BillUrl { get; set; } = null!;
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
    }
}
