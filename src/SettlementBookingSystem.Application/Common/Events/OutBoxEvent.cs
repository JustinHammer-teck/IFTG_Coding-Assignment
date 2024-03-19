using MediatR;
using SettlementBookingSystem.Domain.Common;

namespace SettlementBookingSystem.Application.Common.Events
{
    public class OutBoxEvent<TDomainEvent> : INotification where TDomainEvent : DomainEvent
    {
        public OutBoxEvent(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
        public TDomainEvent DomainEvent { get; }
    }
}