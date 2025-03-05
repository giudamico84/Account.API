using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using FluentAssertions;
using Account.Domain.Interfaces;

namespace Account.Infrastructure.Test
{
    public class ServiceCollectionExtensionsTest
    {
        private static IServiceProvider Provider()
        {
            var services = new ServiceCollection();
            services.AddInfrastructureServices(Substitute.For<IConfiguration>());
            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>() where T : notnull
        {
            var provider = Provider();
            return provider.GetRequiredService<T>();
        }

        [Fact]
        public void ShouldResolve_IJwtProvider()
        {
            var result = GetRequiredService<IJwtProvider>();
            result.Should().NotBeNull();
        }
    }
}