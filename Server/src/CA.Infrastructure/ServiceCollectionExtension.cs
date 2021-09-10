using CA.Application.Common.Interfaces;
using CA.Infrastructure.Persistence;
using CA.Infrastructure.Persistence.Data.BaseRepository;
using CA.Infrastructure.Persistence.Data.BaseRepository.Interfaces;
using CA.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure
{
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
            var assembly = typeof(AppDbContext).Assembly.FullName;

            service.AddDbContextPool<AppDbContext>(_ =>
            {
                _.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(assembly));
            });

            service.AddScoped<IAppDbContext>(factory => factory.GetService<AppDbContext>());
        }

        internal static void LoadServices(this IServiceCollection service)
        {
            service.AddScoped<IDomainEventService, DomainEventService>();
        }

        internal static void LoadRepositories(this IServiceCollection service)
        {
            service.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}