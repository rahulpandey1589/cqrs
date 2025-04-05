namespace Cqrs.Domain.Core;

public abstract class DomainEvent : IDomainEvent
{
        public DateTime DateOccurred { get; }

        public DomainEvent()
        {
            DateOccurred = DateTime.UtcNow;
        }
}