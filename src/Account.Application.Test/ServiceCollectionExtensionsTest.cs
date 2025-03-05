using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using FluentAssertions;
using MediatR;

namespace Account.Application.Test
{
    public class ServiceCollectionExtensionsTest
    {
        private static IServiceProvider Provider()
        {
            var services = new ServiceCollection();
            services.AddApplicationServices(Substitute.For<IConfiguration>());
            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>() where T : notnull
        {
            var provider = Provider();
            return provider.GetRequiredService<T>();
        }

        [Fact]
        public void ShouldResolve_IMediator()
        {
            var result = GetRequiredService<IMediator>();
            result.Should().NotBeNull();
        }
    }
}