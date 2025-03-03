using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using FluentAssertions;

namespace Account.Api.Test
{
    public class ServiceCollectionExtensionsTest
    {
        private static IServiceProvider Provider()
        {
            var services = new ServiceCollection();
            services.Setup(Substitute.For<IConfiguration>());
            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>() where T : notnull
        {
            var provider = Provider();
            return provider.GetRequiredService<T>();
        }        
    }
}