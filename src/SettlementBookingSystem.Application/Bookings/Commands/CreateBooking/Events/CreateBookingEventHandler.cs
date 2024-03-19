using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SettlementBookingSystem.Application.Common.Events;
using SettlementBookingSystem.Domain.Events;
using SettlementBookingSystem.Infrastructure.OutBoxConfigurations;
using SettlementBookingSystem.Infrastructure.Persistence;

namespace SettlementBookingSystem.Application.Bookings.Commands.CreateBooking.Events
{
    public class CreateBookingEventHandler : INotificationHandler<OutBoxEvent<CreateBookingEvent>>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateBookingEventHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(OutBoxEvent<CreateBookingEvent> notification, CancellationToken cancellationToken)
        {
            var outboxEvent = new OutBoxEvent(
                Guid.NewGuid().ToString(),
                JsonSerializer.Serialize(notification.DomainEvent),
                notification.DomainEvent.GetType().Name);

            _dbContext.OutBoxEvents.Add(outboxEvent);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}