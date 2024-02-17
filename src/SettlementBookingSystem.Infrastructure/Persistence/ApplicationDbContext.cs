using Microsoft.EntityFrameworkCore;
using SettlementBookingSystem.Application.Common.Interfaces;
using SettlementBookingSystem.Domain.Entities;

namespace SettlementBookingSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Booking> Bookings { get; set; }
    }
}