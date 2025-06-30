using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Purchases;

namespace WebApplication.Application.Features.Purchases.Commands
{
    public class UpdatePurchaseByIdCommand : IRequest<Result<PurchaseDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public PurchaseUpdateDto Entity { get; set; }

        public string[] CacheKeys => [$"purchase:{Id}", "purchases*"];
    }
}
