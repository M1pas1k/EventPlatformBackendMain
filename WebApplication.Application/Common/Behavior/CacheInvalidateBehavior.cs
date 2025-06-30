using WebApplication.Application.Interfaces;
using MediatR;

namespace WebApplication.Application.Common.Behavior
{
    public class CacheInvalidateBehavior<Request, Response>(ICache cache) : IPipelineBehavior<Request, Response>
    where Request : IRequest<Response>, ICacheInvalidate

    {
        public async Task<Response> Handle(Request request, RequestHandlerDelegate<Response> next, CancellationToken cancellationToken)
        {
            foreach (var key in request.CacheKeys)
                await cache.RemoveKeysMask(key);

            return await next();
        }
    }
}
