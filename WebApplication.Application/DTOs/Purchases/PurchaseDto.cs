using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;

namespace WebApplication.Application.DTOs.Purchases
{
    public class PurchaseDto : IMapWith<Purchase>
    {
        public string ProductUrl { get; set; }
        public string BillUrl { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        public DateTime Date { get; set; }
        public PurchaseStatus Status { get; set; }
    }
}
