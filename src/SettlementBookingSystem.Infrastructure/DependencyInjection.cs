using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SettlementBookingSystem.Application.Common.Interfaces.Repository;
using SettlementBookingSystem.Infrastructure.Persistence;
using SettlementBookingSystem.Infrastructure.Repositories;

namespace SettlementBookingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("SettlementBooking"));

            services.AddEntityFrameworkInMemoryDatabase();

            services.AddScoped<IBookingRepository, BookingRepository>();
            
            return services;
        }
    }
}