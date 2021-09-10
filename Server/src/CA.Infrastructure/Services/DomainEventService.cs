using CA.Application.Common.Interfaces;
using CA.Application.Common.Models;
using CA.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CA.Infrastructure.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly ILogger<DomainEventService> _logger;
        private readonly IPublisher _publisher;

        public DomainEventService(ILogger<DomainEventService> logger, IPublisher publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }
        public async Task Publish(DomainEvent domainEvent)
        {
            _logger.LogInformation("Published domain event. Event : {event}", domainEvent.GetType().Name);
            await _publisher.Publish(this.GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification)Activator.CreateInstance(typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
        }
    }
}