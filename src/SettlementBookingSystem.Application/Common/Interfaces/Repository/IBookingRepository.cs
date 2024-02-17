using SettlementBookingSystem.Application.Bookings.Commands.CreateBookingCommand;
using SettlementBookingSystem.Application.Bookings.Models;

namespace SettlementBookingSystem.Application.Common.Interfaces.Repository
{
    public interface IBookingRepository
    {
        bool TryAddBooking(out BookingDto bookingDto, CreateBookingCommand command);
    }
}