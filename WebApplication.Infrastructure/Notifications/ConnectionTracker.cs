using WebApplication.Application.Interfaces;
using WebApplication.Infrastructure.Interfaces;

namespace WebApplication.Infrastructure.Notifications
{
    public class ConnectionTracker(ICache cache) : IConnectionTracker
    {
        private readonly string _prefix = "connections";

        public async Task AddConnection(string userId, string connectionId, CancellationToken ct = default)
        {
            await cache.SetAddAsync($"{_prefix}:user:{userId}", connectionId, ct);
            await cache.StringSetAsync($"{_prefix}:{connectionId}", userId, ct);
        }

        public async Task RemoveConnection(string userId, string connectionId, CancellationToken ct = default)
        {
            await cache.SetRemoveAsync($"{_prefix}:user:{userId}", connectionId, ct);
            await cache.RemoveAsync($"{_prefix}:{connectionId}", ct);
        }

        public async Task<bool> IsUserConnected(string userId)
        {
            return (await cache.SetLength($"{_prefix}:user:{userId}")) > 0;
        }
    }
}
