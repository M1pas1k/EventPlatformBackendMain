using WebApplication.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace WebApplication.Infrastructure.Notifications
{

    [Authorize]
    public class NotificationHub(IConnectionTracker tracker) : Hub
    {
        private string GetUserId() => Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public override async Task OnConnectedAsync()
        {
            var userId = GetUserId();
            Context.Items["userId"] = userId;
            await tracker.AddConnection(userId, Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = GetUserId();
            await tracker.RemoveConnection(userId, Context.ConnectionId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
