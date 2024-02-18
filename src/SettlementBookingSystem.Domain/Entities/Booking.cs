using System;

namespace SettlementBookingSystem.Domain.Entities
{
    public class Booking
    {
        public Booking()
        {
        }

        private Booking(string name, string bookingTime)
        {
            Id = new Guid();
            Name = name;
            BookingTime = bookingTime;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string BookingTime { get; private set; }

        public static Booking Create(string name, string bookingTime)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            
            if (string.IsNullOrEmpty(bookingTime))
            {
                throw new ArgumentNullException(nameof(bookingTime));
            }

            return new Booking(name, bookingTime);
        }
    }
}