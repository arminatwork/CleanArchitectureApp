using CA.SharedKernel.Application.Interfaces;
using CA.Todos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CA.Todos.Infrastructure.Persistence
{
    public class TodoDbContext : DbContext, IAppDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDomainEventService _domainEventService;
        public TodoDbContext(DbContextOptions options,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService) : base(options)
        {
            _currentUserService = currentUserService;
            _domainEventService = domainEventService;
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<TodoList> TodoLists { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }


        //should be implement this configuration at base db context
#if false
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateBy = _currentUserService.UserId;
                        entry.Entity.CreateDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifyBy = _currentUserService.UserId;
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
                await _domainEventService.Publish(domainEventEntity);
            }
        }
#endif
    }
}