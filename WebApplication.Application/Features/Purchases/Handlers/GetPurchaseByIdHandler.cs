using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Purchases;
using WebApplication.Application.Features.Purchases.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Purchases.Handlers
{
    public class GetPurchaseByIdHandler(IActions actions) : IRequestHandler<GetPurchaseByIdQuery, Result<PurchaseDto>>
    {
        public async Task<Result<PurchaseDto>> Handle(GetPurchaseByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Purchase, PurchaseDto>(request.Id, cancellationToken);
        }
    }
}
