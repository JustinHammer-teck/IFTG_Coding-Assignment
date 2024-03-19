using System;

namespace SettlementBookingSystem.Domain.Common
{
    public abstract class DomainEvent 
    {
        public bool IsPublished { get; set; }
        public DateTime DataPublished { get; protected set; } = DateTime.UtcNow;
    }
}