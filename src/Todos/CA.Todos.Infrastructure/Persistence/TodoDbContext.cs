using CA.SharedKernel.Application.Interfaces;
using CA.SharedKernel.Infrastructure;
using CA.Todos.Domain;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace CA.Todos.Infrastructure.Persistence;

public class TodoDbContext : BaseDbContext, IAppDbContext
{
    public TodoDbContext(DbContextOptions options,
        ICurrentUserService currentUserService,
        IDomainEventService domainEventService) : base(options, currentUserService, domainEventService)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }

    public DbSet<TodoList> TodoLists { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
