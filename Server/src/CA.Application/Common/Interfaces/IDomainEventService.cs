using CA.Domain.Common;
using System.Threading.Tasks;

namespace CA.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
