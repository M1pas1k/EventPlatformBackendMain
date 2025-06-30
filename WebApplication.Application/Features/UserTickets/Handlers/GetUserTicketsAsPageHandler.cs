using AutoMapper;
using MediatR;
using WebApplication.Application.DTOs.UserTickets;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.UserTickets.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.UserTickets.Handlers
{
    public class GetUserTicketsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUserTicketsAsPageQuery, Page<UserTicketDto>>
    {
        public async Task<Page<UserTicketDto>> Handle(GetUserTicketsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.UsersTickets.AsQueryable().PaginateAsync<UserTicket, UserTicketDto>(request.Page, mapper, cancellationToken);
        }
    }
}
