using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Purchases;
using WebApplication.Application.Features.Purchases.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Purchases.Handlers
{
    public class CreatePurchaseHandler(IActions actions) : IRequestHandler<CreatePurchaseCommand, Result<PurchaseDto>>
    {
        public async Task<Result<PurchaseDto>> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Purchase, PurchaseDto>(request.Entity, cancellationToken);
        }
    }
}
