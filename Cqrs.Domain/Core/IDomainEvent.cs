using MediatR;

namespace Cqrs.Domain.Core;

public interface IDomainEvent : INotification
{
    DateTime DateOccurred { get; }
}