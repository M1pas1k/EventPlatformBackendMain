using WebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication.Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("tickets");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("id");

            builder.Property(t => t.Title)
                .HasColumnName("title")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Price)
                .HasColumnName("price")
                .HasColumnType("numeric(10,2)");

            builder.Property(e => e.AvailableCount)
                .HasColumnName("available_count")
                .HasColumnType("bigint");

            builder.HasMany(t => t.UserTickets)
                .WithOne(ut => ut.Ticket)
                .HasForeignKey(t => t.TicketId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
