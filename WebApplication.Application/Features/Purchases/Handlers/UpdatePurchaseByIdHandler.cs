using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Purchases;
using WebApplication.Application.Features.Purchases.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Purchases.Handlers
{
    public class UpdatePurchaseByIdHandler(IActions actions) : IRequestHandler<UpdatePurchaseByIdCommand, Result<PurchaseDto>>
    {
        public async Task<Result<PurchaseDto>> Handle(UpdatePurchaseByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Purchase, PurchaseDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
