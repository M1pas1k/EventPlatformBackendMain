using WebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication.Infrastructure.Persistence.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("purchases");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.ProductUrl)
                .HasColumnName("product_url")
                .IsRequired();

            builder.Property(p => p.Amount)
                .HasColumnName("amount")
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description");

            builder.Property(p => p.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.Date)
                .HasColumnName("date")
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.Property(p => p.CustomerId)
                .HasColumnName("customer_id");
        }
    }
}
