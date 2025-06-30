using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebApplication.Application.DTOs.Tickets;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.Tickets.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Tickets.Handlers
{
    public class GetTicketsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetTicketsAsPageQuery, Page<TicketDto>>
    {
        public async Task<Page<TicketDto>> Handle(GetTicketsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Tickets.ProjectTo<TicketDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
