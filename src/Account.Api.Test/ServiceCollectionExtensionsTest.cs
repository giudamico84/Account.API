using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using FluentAssertions;
using Account.Domain.Interfaces;

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