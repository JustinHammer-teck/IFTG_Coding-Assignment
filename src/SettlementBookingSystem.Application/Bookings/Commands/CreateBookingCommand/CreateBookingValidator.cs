using FluentValidation;
using SettlementBookingSystem.Application.Common.Statics;

namespace SettlementBookingSystem.Application.Bookings.Commands.CreateBookingCommand
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.BookingTime).Matches(Static.HourFormatRegex);
        }
    }
}