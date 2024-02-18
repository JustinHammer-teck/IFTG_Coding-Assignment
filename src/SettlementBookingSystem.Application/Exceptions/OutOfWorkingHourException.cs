using FluentValidation;

namespace SettlementBookingSystem.Application.Exceptions
{
    public class OutOfWorkingHourException : ValidationException
    {
        public OutOfWorkingHourException(string message)
            : base(message)
        {
        }
    }
}