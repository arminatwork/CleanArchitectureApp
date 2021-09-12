using CA.SharedKernel.Domain;
using System.Threading.Tasks;

namespace CA.SharedKernel.Application.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
