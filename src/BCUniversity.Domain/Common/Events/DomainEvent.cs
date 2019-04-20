using System;

namespace BCUniversity.Domain.Common.Events
{
    public abstract class DomainEvent
    {
        public DateTime EventDateTime { get; } = DateTime.UtcNow;
    }
}