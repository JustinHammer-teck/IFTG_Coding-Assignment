using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SettlementBookingSystem.Domain.Entities;

namespace SettlementBookingSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Booking> Bookings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbTransaction> BeginTransaction();
    }
}