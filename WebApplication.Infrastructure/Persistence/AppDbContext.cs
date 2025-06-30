using System.Reflection;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Spi;

namespace WebApplication.Infrastructure.Persistence
{
    public class AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : DbContext(options), IDatabaseContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Tag> EventTags { get; set; }

        public DbSet<EventMood> EventMoods { get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<UserTicket> UsersTickets { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder models)
        {
            models.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
