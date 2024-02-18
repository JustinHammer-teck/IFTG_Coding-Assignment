using System;

namespace SettlementBookingSystem.Application.Options
{
    public class BookingSystemOptions
    {
        public int SettlementSlot { get; set; }
        public WorkingHour WorkingHour { get; set; }
        public int BookingInterval { get; set; }
    }

    public class WorkingHour
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}