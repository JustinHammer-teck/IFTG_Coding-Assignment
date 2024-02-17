using Microsoft.EntityFrameworkCore;
using SettlementBookingSystem.Domain.Entities;

namespace SettlementBookingSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Booking> Bookings { get; set; }
    }
}