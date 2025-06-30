using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.Features.Tags.Queries;
using WebApplication.Application.Pagination;

namespace WebApplication.API.Controllers.Customer
{
    [Tags("Events")]
    [Authorize]
    [ApiController]
    [Route("/api/tags")]
    public class TagsController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetTagsQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetTagByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetTagsAsPageQuery() { Page = page }));
        }

    }
}
