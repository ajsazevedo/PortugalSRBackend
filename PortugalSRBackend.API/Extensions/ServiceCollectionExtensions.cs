using PortugalSRBackend.Application.Services.Base;
using PortugalSRBackend.Core.Interfaces.Services.Base;
using PortugalSRBackend.Core.Objects.Setup;
using System.Reflection;

namespace PortugalSRBackend.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServiceOptions(configuration);

            // Add services to the container.
            services.AddScopedServices();
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void AddServiceOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions().Configure<HackerNewsSetup>(configuration.GetSection("HackerNews"));
        }

        public static void AddScopedServices(this IServiceCollection services)
        {
            services.UseAllOfType(new[] { typeof(BaseService).Assembly, typeof(IBaseService).Assembly }, "Service");
        }

        public static void UseAllOfType(this IServiceCollection services, Assembly[] assemblies, string serviceType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.AddDependenciesByNamingConvention(
                assemblies,
                x => x.Name.EndsWith(serviceType),
                lifetime
            );
        }

        public static void AddDependenciesByNamingConvention(this IServiceCollection services, Assembly[] assemblies, Func<Type, bool> predicate, ServiceLifetime lifetime)
        {
            var implementations = new List<Type>();
            var interfaces = new List<Type>();

            foreach (var assembly in assemblies)
            {
                implementations.AddRange(assembly.ExportedTypes
                    .Where(x => !x.IsInterface && predicate(x)));
                interfaces.AddRange(assembly.ExportedTypes
                    .Where(x => x.IsInterface && predicate(x)));
            }

            foreach (var @interface in interfaces)
            {
                var implementation = implementations
                    .FirstOrDefault(x => @interface.IsAssignableFrom(x)
                        && $"I{x.Name}" == @interface.Name && !x.IsAbstract);

                if (implementation == null)
                    throw new InvalidOperationException(string.Format("Not found implementation for interface {0}", @interface));

                switch (lifetime)
                {
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(@interface, implementation);
                        break;
                    case ServiceLifetime.Scoped:
                        services.AddScoped(@interface, implementation);
                        break;
                    default:
                        services.AddTransient(@interface, implementation);
                        break;
                }
            }
        }
    }
}
