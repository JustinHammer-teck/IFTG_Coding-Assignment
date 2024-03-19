using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SettlementBookingSystem.Domain.Entities;
using SettlementBookingSystem.Infrastructure.OutBoxConfigurations;

namespace SettlementBookingSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Booking> Bookings { get; set; }
        
        public DbSet<OutBoxEvent> OutBoxEvents { get; set; }

        public async Task<IDbTransaction> BeginTransaction()
        {
            var transaction = await base.Database.BeginTransactionAsync();

            return transaction.GetDbTransaction();
        }
    }
}