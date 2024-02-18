using System;
using System.Collections.Generic;
using SettlementBookingSystem.Application.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using SettlementBookingSystem.Application.Bookings.Commands.CreateBooking;
using SettlementBookingSystem.Application.Bookings.Commands.CreateBooking.Models;
using SettlementBookingSystem.Application.Common.Interfaces;
using SettlementBookingSystem.Application.Options;
using SettlementBookingSystem.Application.UnitTests.Helpers;
using SettlementBookingSystem.Domain.Entities;
using Xunit;

namespace SettlementBookingSystem.Application.UnitTests
{
    public class CreateBookingCommandHandlerTests
    {
        private readonly Mock<IOptions<BookingSystemOptions>> _mockOptions;
        private readonly Mock<IApplicationDbContext> _mockDbContext;
        private readonly Mock<IMapper> _mockMapper;

        public CreateBookingCommandHandlerTests()
        {
            _mockOptions = new Mock<IOptions<BookingSystemOptions>>();
            _mockDbContext = new Mock<IApplicationDbContext>();
            _mockMapper = new Mock<IMapper>();

            // Setup fake working hours in BookingSystemOptions
            _mockOptions.Setup(opt => opt.Value).Returns(new BookingSystemOptions
            {
                WorkingHour = new WorkingHour { From = "08:00", To = "18:00" },
                BookingInterval = 15,
                SettlementSlot = 1 // Assuming 1 booking per time slot for simplicity
            });
        }

        [Fact]
        public async Task GivenValidBookingTime_WhenNoConflictingBookings_ThenBookingIsAccepted()
        {
            //Arrange
            var command = new CreateBookingCommand
            {
                Name = "test",
                BookingTime = "09:15",
            };

            var bookingList = new List<Booking>();
            var mockSet = MockDbSet.GetMockDbSet(bookingList);
            _mockDbContext.Setup(db => db.Bookings).Returns(mockSet);

            var fakeBookingDto = new BookingDto { BookingId = Guid.NewGuid().ToString() };
            _mockMapper.Setup(mapper => mapper.Map<BookingDto>(It.IsAny<Booking>())).Returns(fakeBookingDto);

            var handler =
                new CreateBookingCommandHandler(_mockOptions.Object, _mockDbContext.Object, _mockMapper.Object);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.BookingId.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GivenOutOfHoursBookingTime_WhenBooking_ThenValidationFails()
        {
            // Arrange
            var command = new CreateBookingCommand
            {
                Name = "test",
                BookingTime = "00:00", // Out of working hours
            };

            var handler =
                new CreateBookingCommandHandler(_mockOptions.Object, _mockDbContext.Object, _mockMapper.Object);

            // Act
            var result = new Func<Task<BookingDto>>(() => handler.Handle(command, CancellationToken.None));

            // Assert
            await Assert.ThrowsAsync<OutOfWorkingHourException>(result);
        }

        [Fact]
        public void GivenValidBookingTime_WhenBookingIsFull_ThenConflictThrown()
        {
            // Arrange
            var command = new CreateBookingCommand
            {
                Name = "test",
                BookingTime = "09:15",
            };

            var bookingList = new List<Booking>
            {
                Booking.Create("Existing Booking", command.BookingTime)
            };

            var mockSet = MockDbSet.GetMockDbSet(bookingList);
            _mockDbContext.Setup(db => db.Bookings).Returns(mockSet);

            var handler =
                new CreateBookingCommandHandler(_mockOptions.Object, _mockDbContext.Object, _mockMapper.Object);

            // Act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            // Assert
            act.Should().Throw<ConflictException>();
        }
    }
}