using AutoMapper;
using SettlementBookingSystem.Application.Common.Mapping;
using SettlementBookingSystem.Domain.Entities;

namespace SettlementBookingSystem.Application.Bookings.Commands.CreateBooking.Models
{
    public class BookingDto : IMapFrom<Booking>
    {
        public string BookingId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.BookingId,
                    opt => opt.MapFrom(x => x.Id.ToString()));
        }
    }
}