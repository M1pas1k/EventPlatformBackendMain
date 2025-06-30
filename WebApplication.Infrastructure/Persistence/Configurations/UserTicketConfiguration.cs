using WebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication.Infrastructure.Persistence.Configurations
{
    public class UserTicketConfiguration : IEntityTypeConfiguration<UserTicket>
    {
        public void Configure(EntityTypeBuilder<UserTicket> builder)
        {
            builder.ToTable("user_tickets");

            builder.HasKey(ut => ut.Id);
            builder.Property(ut => ut.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();


            builder.Property(ut => ut.TicketStatus)
                .HasColumnName("ticket_status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
