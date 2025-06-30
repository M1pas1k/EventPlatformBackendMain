using WebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<EventMood> EventMoods { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Tag> EventTags { get; set; }
        DbSet<EventType> EventTypes { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<RefreshToken> RefreshTokens { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserTicket> UsersTickets { get; set; }
        DbSet<Purchase> Purchases { get; set; }

        Task<int> SaveChangesAsync(CancellationToken ct);
        int SaveChanges();
    }
}
