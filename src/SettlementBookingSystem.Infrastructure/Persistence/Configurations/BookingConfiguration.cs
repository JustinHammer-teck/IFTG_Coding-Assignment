using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SettlementBookingSystem.Domain.Entities;

namespace SettlementBookingSystem.Infrastructure.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.BookingTime)
                .IsRequired();
        }
    }
}