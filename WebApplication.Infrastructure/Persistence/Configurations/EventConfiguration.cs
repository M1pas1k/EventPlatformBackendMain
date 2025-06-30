using WebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication.Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("events");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.ImageId)
                .HasColumnName("image_id")
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(600)
                .IsRequired();

            builder.Property(e => e.AdditionalRequirements)
                .HasColumnName("additional_requirements")
                .HasColumnType("text");

            builder.Property(e => e.StartAt)
                .HasColumnName("start_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.Property(e => e.EndAt)
                .HasColumnName("end_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.Property(e => e.Latitude)
                .HasColumnName("latitude")
                .HasColumnType("double precision");

            builder.Property(e => e.Longitude)
                .HasColumnName("longitude")
                .HasColumnType("double precision");

            builder.Property(e => e.ReturnedTickets)
                .HasColumnName("returned_tickets")
                .HasColumnType("bigint");

            builder.Property(e => e.Status)
                .HasColumnName("moderation_status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(e => e.Creator)
                .WithMany(u => u.Events)
                .HasForeignKey(e => e.CreatorId)
                .IsRequired();

            builder.HasOne(e => e.EventType)
                .WithMany(et => et.Events)
                .HasForeignKey(e => e.EventTypeId)
                .IsRequired();

            builder.HasOne(e => e.EventMood)
                .WithMany(em => em.Events)
                .HasForeignKey(e => e.EventMoodId)
                .IsRequired();

            builder.HasMany(e => e.Tags)
                .WithMany(t => t.Events)
                .UsingEntity(j => j.ToTable("event_tags"));

            builder.HasMany(e => e.Tickets)
                .WithOne(t => t.Event)
                .HasForeignKey(t => t.EventId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
