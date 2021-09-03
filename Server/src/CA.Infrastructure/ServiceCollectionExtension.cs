using CA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void LoadDbContext(this IServiceCollection service, string connectionString)
        {
            var assembly = typeof(AppDbContext).Assembly.FullName;

            service.AddDbContextPool<AppDbContext>(_ =>
            {
                _.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(assembly));
            });
        }
    }
}