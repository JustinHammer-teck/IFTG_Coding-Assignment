using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SettlementBookingSystem.Application.Bookings.Models;
using SettlementBookingSystem.Application.Common.Interfaces.Repository;

namespace SettlementBookingSystem.Application.Bookings.Commands.CreateBookingCommand
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDto>
    {
        private readonly IBookingRepository _bookingRepository;
        
        public CreateBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Task<BookingDto> Handle(Commands.CreateBookingCommand.CreateBookingCommand request, CancellationToken cancellationToken)
        {
            // TODO Implement CreateBookingCommandHandler.Handle() and confirm tests are passing. See InfoTrack Global Team - Tech Test.pdf for business rules.
            throw new NotImplementedException();
        }
    }
}
