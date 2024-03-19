using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SettlementBookingSystem.Infrastructure.Persistence;

namespace SettlementBookingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ApplicationDbContext>();
            
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseInMemoryDatabase("SettlementBooking"));
            var connnectionString = "";
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connnectionString));
            
            // services.AddEntityFrameworkInMemoryDatabase();

            return services;
        }
    }
}