using Account.Application;
using Account.Infrastructure;

namespace Account.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Setup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices(configuration);
            services.AddInfrastructureServices(configuration);

            return services;
        }
    }
}
