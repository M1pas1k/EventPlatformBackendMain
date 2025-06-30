using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;
using WebApplication.Infrastructure.PasswordHash;

namespace WebApplication.API.Initializers
{
    public static class DbInitializer
    {
        public static void Initialize(IDatabaseContext context)
        {
            if (context.Users.Any() && context.Events.Any())
                return;

            var roles = GenerateRoles();
            var eventTypes = GenerateEventTypes();
            var eventMoods = GenerateEventMoods();
            var tags = GenerateTags();

            context.Roles.AddRange(roles);
            context.EventTypes.AddRange(eventTypes);
            context.EventMoods.AddRange(eventMoods);
            context.EventTags.AddRange(tags);
            context.SaveChanges();

            var users = GenerateUsers(roles);
            context.Users.AddRange(users);
            context.SaveChanges();

            var events = GenerateEvents(users, eventTypes, eventMoods, tags);
            context.Events.AddRange(events);
            context.SaveChanges();

            var tickets = GenerateTickets(events);
            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            var userTickets = GenerateUserTickets(users, tickets);
            context.UsersTickets.AddRange(userTickets);

            var notifications = GenerateNotifications(users);
            context.Notifications.AddRange(notifications);

            context.SaveChanges();
        }

        private static List<Role> GenerateRoles()
        {
            return new List<Role>
            {
                new Role { Id = Guid.NewGuid(), Name = "Admin"},
                new Role { Id = Guid.NewGuid(), Name = "Organizer", isPublic = true},
                new Role { Id = Guid.NewGuid(), Name = "User", isPublic = true}
            };
        }

        private static List<EventType> GenerateEventTypes()
        {
            return new List<EventType>
            {
                new EventType { Id = Guid.NewGuid(), Title = "Concert", IsAvailable = true },
                new EventType { Id = Guid.NewGuid(), Title = "Conference", IsAvailable = true },
                new EventType { Id = Guid.NewGuid(), Title = "Workshop", IsAvailable = false }
            };
        }

        private static List<EventMood> GenerateEventMoods()
        {
            return new List<EventMood>
            {
                new EventMood { Id = Guid.NewGuid(), Title = "Festive" },
                new EventMood { Id = Guid.NewGuid(), Title = "Business" },
                new EventMood { Id = Guid.NewGuid(), Title = "Casual" }
            };
        }

        private static List<Tag> GenerateTags()
        {
            return new List<Tag>
            {
                new Tag { Id = Guid.NewGuid(), Title = "Music" },
                new Tag { Id = Guid.NewGuid(), Title = "Tech" },
                new Tag { Id = Guid.NewGuid(), Title = "Food" }
            };
        }

        private static List<User> GenerateUsers(List<Role> roles)
        {
            var passwordHasher = new PasswordHasher();
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@example.com",
                    Name = "Admin User",
                    PhoneNumber = "+1234567890",
                    PasswordHash = passwordHasher.Hash("Admin123!"),
                    Birthdate = new DateTime(1980, 1, 1).ToUniversalTime(),
                    Roles = new List<Role> { roles[0] }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "organizer@example.com",
                    Name = "Event Organizer",
                    PhoneNumber = "+0987654321",
                    PasswordHash = passwordHasher.Hash("Organizer123!"),
                    Birthdate = new DateTime(1985, 5, 15).ToUniversalTime(),
                    Roles = new List<Role> { roles[1] }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "user@example.com",
                    Name = "Regular User",
                    PhoneNumber = "+1112223333",
                    PasswordHash = passwordHasher.Hash("User123!"),
                    Birthdate = new DateTime(1990, 10, 20).ToUniversalTime(),
                    Roles = new List<Role> { roles[2] }
                }
            };
            return users;
        }

        private static List<Event> GenerateEvents(
            List<User> users,
            List<EventType> eventTypes,
            List<EventMood> eventMoods,
            List<Tag> tags)
        {
            var events = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Rock Concert 2023",
                    Description = "Annual rock music festival",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    ReturnedTickets = 50,
                    StartAt = DateTime.UtcNow.AddDays(30),
                    EndAt = DateTime.UtcNow.AddDays(33),
                    AdditionalRequirements = "Age 18+",
                    Status = EventStatus.Approved,
                    Creator = users[1],
                    EventType = eventTypes[0],
                    EventMood = eventMoods[0],
                    Tags = new List<Tag> { tags[0] }
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Tech Summit 2023",
                    Description = "International technology conference",
                    Latitude = 37.7749,
                    Longitude = -122.4194,
                    ReturnedTickets = 20,
                    StartAt = DateTime.UtcNow.AddDays(45),
                    EndAt = DateTime.UtcNow.AddDays(48),
                    AdditionalRequirements = "Business attire",
                    Status = EventStatus.UnderModeration,
                    Creator = users[1],
                    EventType = eventTypes[1],
                    EventMood = eventMoods[1],
                    Tags = new List<Tag> { tags[1], tags[2] }
                }
            };
            return events;
        }

        private static List<Ticket> GenerateTickets(List<Event> events)
        {
            return new List<Ticket>
            {
                new Ticket
                {
                    Id = Guid.NewGuid(),
                    Title = "VIP Pass",
                    Price = 299.99m,
                    Event = events[0],
                    AvailableCount = 5,
                },
                new Ticket
                {
                    Id = Guid.NewGuid(),
                    Title = "General Admission",
                    Price = 99.99m,
                    Event = events[0],
                    AvailableCount = 9,

                },
                new Ticket
                {
                    Id = Guid.NewGuid(),
                    Title = "Conference Full Pass",
                    Price = 499.99m,
                    Event = events[1],
                    AvailableCount = 1,
                }
            };
        }

        private static List<UserTicket> GenerateUserTickets(List<User> users, List<Ticket> tickets)
        {
            return new List<UserTicket>
            {
                new UserTicket
                {
                    Id = Guid.NewGuid(),
                    TicketStatus = UserTicketStatus.Active,
                    User = users[2],
                    Ticket = tickets[0]
                },
                new UserTicket
                {
                    Id = Guid.NewGuid(),
                    TicketStatus = UserTicketStatus.Returned,
                    User = users[2],
                    Ticket = tickets[1]
                }
            };
        }

        private static List<Notification> GenerateNotifications(List<User> users)
        {
            return new List<Notification>
            {
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Subject = "Welcome to EventPlatform",
                    Content = "Your account was created successfully",
                    Type = NotificationType.Info,
                    User = users[2]
                },
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Subject = "Event Approved",
                    Content = "Your event 'Rock Concert 2023' has been approved",
                    Type = NotificationType.Info,
                    User = users[1]
                }
            };
        }

    }
}
