using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Purchases;

namespace WebApplication.Application.Features.Purchases.Commands
{
    public class CreatePurchaseCommand : IRequest<Result<PurchaseDto>>, ICacheInvalidate
    {
        public PurchaseCreateDto Entity { get; set; }
        public string[] CacheKeys => ["purchases*"];
    }
}
