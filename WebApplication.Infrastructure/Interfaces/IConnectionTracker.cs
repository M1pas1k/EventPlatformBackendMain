namespace WebApplication.Infrastructure.Interfaces
{
    public interface IConnectionTracker
    {
        Task AddConnection(string userId, string connectionId, CancellationToken ct = default);
        Task<bool> IsUserConnected(string userId);
        Task RemoveConnection(string userId, string connectionId, CancellationToken ct = default);
    }
}