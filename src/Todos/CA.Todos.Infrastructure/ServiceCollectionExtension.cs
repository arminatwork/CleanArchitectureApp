using CA.Todos.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.LoadDbContext(connectionString);

        services.LoadServices();

        services.LoadRepositories();
    }

    internal static void LoadDbContext(this IServiceCollection service, string connectionString)
    {
        var assembly = typeof(TodoDbContext).Assembly.FullName;

        service.AddDbContextPool<TodoDbContext>(_ =>
        {
            _.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(assembly));
        });

        //TODO: i will check this
        //service.AddScoped<IAppDbContext>(factory => factory.GetService<AppDbContext>());
    }

    //TODO: i will check this
    internal static void LoadServices(this IServiceCollection service)
    {
        //service.AddScoped<IDomainEventService, DomainEventService>();
    }

    //TODO: i will check this
    internal static void LoadRepositories(this IServiceCollection service)
    {
        //service.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
        //service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
