using CA.SharedKernel.Domain;

namespace CA.SharedKernel.Application.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
