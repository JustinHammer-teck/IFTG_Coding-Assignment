using MediatR;
using SettlementBookingSystem.Application.Bookings.Models;

namespace SettlementBookingSystem.Application.Bookings.Commands.CreateBookingCommand
{
    public class CreateBookingCommand : IRequest<BookingDto>
    {
        public string Name { get; set; }
        public string BookingTime { get; set; }
    }
}
