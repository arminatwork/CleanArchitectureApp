using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CA.Todos.Application
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            //services.AddMediatR(assembly);
        }
    }
}