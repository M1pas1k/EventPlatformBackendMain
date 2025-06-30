using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Purchases;

namespace WebApplication.Application.Features.Purchases.Queries
{
    public class GetPurchaseByIdQuery : IRequest<Result<PurchaseDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"purchase:{Id}";
    }
}
