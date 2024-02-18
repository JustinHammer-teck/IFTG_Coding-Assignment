using FluentValidation;
using SettlementBookingSystem.Application.Common.Statics;

namespace SettlementBookingSystem.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingValidator : AbstractValidator<CreateBooking.CreateBookingCommand>
    {
        public CreateBookingValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.BookingTime).Matches(Static.HourFormatRegex);
        }
    }
}