using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Events;
using WebApplication.Application.Features.Events.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Events.Handlers
{
    public class CreateEventHandler(IActions actions) : IRequestHandler<CreateEventCommand, Result<EventDto>>
    {
        public async Task<Result<EventDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Event, EventDto>(request, cancellationToken, async (event_, context) =>
            {
                foreach (var tagTitle in request.Entity.TagTitles)
                {
                    var tag = await context.EventTags.FirstOrDefaultAsync(t => t.Title == tagTitle);
                    if (tag is null)
                    {
                        tag = new Tag { Title = tagTitle };
                        context.EventTags.Add(tag);
                    }
                    event_.Tags.Add(tag);
                }
            });
        }
    }
}
