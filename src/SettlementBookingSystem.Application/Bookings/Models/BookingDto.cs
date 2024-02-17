using AutoMapper;
using SettlementBookingSystem.Application.Common.Mapping;
using SettlementBookingSystem.Domain.Entities;

namespace SettlementBookingSystem.Application.Bookings.Models
{
    public class BookingDto : IMapFrom<Booking>
    {
        public string BookingId { get; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, BookingDto>();
        }
    }
}
