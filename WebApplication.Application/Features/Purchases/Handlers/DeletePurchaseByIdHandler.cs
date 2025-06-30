using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Purchases.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Purchases.Handlers
{
    public class DeletePurchaseByIdHandler(IActions actions) : IRequestHandler<DeletePurchaseByIdCommand, Result>
    {
        public async Task<Result> Handle(DeletePurchaseByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Purchase>(request.Id, cancellationToken);
        }
    }
}
