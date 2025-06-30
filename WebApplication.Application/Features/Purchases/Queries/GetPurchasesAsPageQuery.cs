using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Purchases;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Purchases.Queries
{
    public class GetPurchasesAsPageQuery : IRequest<Page<PurchaseDto>>, ICacheable
    {
        public Guid UserId { get; set; }
        public Pageable Page { get; set; }
        public string CacheKey => $"purchases:page:{Page.Index},{Page.Size}";
    }
}
