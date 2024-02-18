using MediatR;
using SettlementBookingSystem.Application.Bookings.Commands.CreateBooking.Models;

namespace SettlementBookingSystem.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<BookingDto>
    {
        public string Name { get; set; }
        public string BookingTime { get; set; }
    }
}
