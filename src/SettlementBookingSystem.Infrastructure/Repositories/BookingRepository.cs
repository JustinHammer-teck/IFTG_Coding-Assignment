using Microsoft.Extensions.Options;
using SettlementBookingSystem.Application.Bookings.Commands.CreateBookingCommand;
using SettlementBookingSystem.Application.Bookings.Models;
using SettlementBookingSystem.Application.Common.Interfaces.Repository;
using SettlementBookingSystem.Application.Options;

namespace SettlementBookingSystem.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingSystemOptions _bookingSystemOptions;

        public BookingRepository(IOptions<BookingSystemOptions> bookingSystemOptions)
        {
            _bookingSystemOptions = bookingSystemOptions.Value;
        }

        public bool TryAddBooking(out BookingDto bookingDto, CreateBookingCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}