using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using SettlementBookingSystem.Application.Bookings.Commands.CreateBooking.Models;
using SettlementBookingSystem.Application.Common.Interfaces;
using SettlementBookingSystem.Application.Exceptions;
using SettlementBookingSystem.Application.Options;
using SettlementBookingSystem.Domain.Entities;

namespace SettlementBookingSystem.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDto>
    {
        private readonly BookingSystemOptions _bookingSystemOptions;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookingCommandHandler(
            IOptions<BookingSystemOptions> bookingSystemOptions,
            IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _bookingSystemOptions = bookingSystemOptions.Value;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var bookingTime = TimeSpan.Parse(request.BookingTime);

            CheckForWorkingHour(bookingTime);
            await CheckForAvailableSlot(bookingTime);

            var booking = Booking.Create(request.Name, request.BookingTime);

            _dbContext.Bookings.Add(booking);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BookingDto>(booking);
        }

        private void CheckForWorkingHour(TimeSpan bookingTime)
        {
            var fromWorkingHour = TimeSpan.Parse(_bookingSystemOptions.WorkingHour.From);
            var lastWorkingHour = TimeSpan
                .Parse(_bookingSystemOptions.WorkingHour.To)
                .Subtract(TimeSpan.FromMinutes(_bookingSystemOptions.BookingInterval));

            if (fromWorkingHour.Hours > bookingTime.Hours || bookingTime.Hours > lastWorkingHour.Hours)
            {
                throw new OutOfWorkingHourException("Out Of Booking Time, Please Try Again Another Time");
            }
        }

        private async Task CheckForAvailableSlot(TimeSpan bookingTime)
        {
            var reversedBooking = _dbContext.Bookings
                .AsEnumerable()
                .Count(b => TimeSpan.Parse(b.BookingTime).Hours == bookingTime.Hours);

            if (reversedBooking >= _bookingSystemOptions.SettlementSlot)
            {
                throw new ConflictException(
                    $"Exceeded Max Reverse Booking Per Booking Interval, Hour: {bookingTime.Hours}");
            }
        }
    }
}