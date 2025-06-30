using WebApplication.Domain.Common;
using WebApplication.Domain.Enums;

namespace WebApplication.Domain.Entities
{
    public class Purchase : BaseEntity
    {
        public string ProductUrl { get; set; } = null!;
        public string BillUrl { get; set; } = null!;
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
        public PurchaseStatus Status { get; set; } = PurchaseStatus.Pending;

        public Guid CustomerId { get; set; }
        public User Customer { get; set; } = null!;
    }
}
