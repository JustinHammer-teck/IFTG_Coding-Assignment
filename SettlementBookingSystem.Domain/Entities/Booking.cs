using System;

namespace SettlementBookingSystem.Domain.Entities
{
    public class Booking
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BookingTime { get; set; }   
    }
}