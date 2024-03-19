using SettlementBookingSystem.Domain.Common;
using SettlementBookingSystem.Domain.Entities;

namespace SettlementBookingSystem.Domain.Events
{
    public class CreateBookingEvent : DomainEvent
    {
        public CreateBookingEvent(Booking booking)
        {
            Booking = booking;
        }

        public Booking Booking { get; }
    }
}