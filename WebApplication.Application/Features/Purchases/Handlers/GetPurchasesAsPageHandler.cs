using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.DTOs.Purchases;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.Purchases.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Purchases.Handlers
{
    public class GetPurchasesAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetPurchasesAsPageQuery, Page<PurchaseDto>>
    {
        public async Task<Page<PurchaseDto>> Handle(GetPurchasesAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Purchases
                .Where(p => p.CustomerId == request.UserId)
                .AsNoTracking()
                .PaginateAsync<Purchase, PurchaseDto>
                (request.Page, mapper, cancellationToken);
        }
    }
}
