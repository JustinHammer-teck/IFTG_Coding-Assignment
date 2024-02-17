using System;

namespace SettlementBookingSystem.Application.Options
{
    public class BookingSystemOptions
    {
        public int SettlementSlot { get; set; }
        public WorkingHour WorkingHour { get; set; }
    }

    public class WorkingHour
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}