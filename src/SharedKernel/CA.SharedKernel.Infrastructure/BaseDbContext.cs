using CA.SharedKernel.Application.Interfaces;
using CA.SharedKernel.Domain;

using Microsoft.EntityFrameworkCore;

namespace CA.SharedKernel.Infrastructure;

public class BaseDbContext : DbContext, IAppDbContext
{
    protected ICurrentUserService CurrentUserService { get; }
    protected IDomainEventService DomainEventService { get; }
    public BaseDbContext(DbContextOptions options,
        ICurrentUserService currentUserService,
        IDomainEventService domainEventService) : base(options)
    {
        CurrentUserService = currentUserService;
        DomainEventService = domainEventService;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreateBy = CurrentUserService.UserId;
                    entry.Entity.CreateDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifyBy = CurrentUserService.UserId;
                    entry.Entity.LastModifyDate = DateTime.Now;
                    break;
                default:
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        await this.DispatchEvents();

        return result;
    }

    private async Task DispatchEvents()
    {
        while (true)
        {
            var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(_ => _.Entity.DomainEvents)
                .SelectMany(_ => _)
                .Where(_ => !_.IsPublished)
                .FirstOrDefault();

            if (domainEventEntity is null) break;

            domainEventEntity.IsPublished = true;
            await DomainEventService.Publish(domainEventEntity);
        }
    }
}
