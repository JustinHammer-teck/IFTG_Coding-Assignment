using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SettlementBookingSystem.Application.Common.Interfaces;
using SettlementBookingSystem.Infrastructure.Persistence;

namespace SettlementBookingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("SettlementBooking"));

            services.AddEntityFrameworkInMemoryDatabase();

            return services;
        }
    }
}