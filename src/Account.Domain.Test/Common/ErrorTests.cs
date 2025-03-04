using Account.Domain.Common;
using FluentAssertions;

namespace Account.Domain.Test.Common
{
    public class ErrorTests
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Act
            var error = new Error("ErrorCode", "Domain", "Description");

            // Assert
            error.Code.Should().Be("ErrorCode");
            error.Domain.Should().Be("Domain");
            error.Description.Should().Be("Description");
        }

        [Fact]
        public void Constructor_WithNullDomainAndDescription_ShouldInitializeCorrectly()
        {
            // Act
            var error = new Error("ErrorCode");

            // Assert
            error.Code.Should().Be("ErrorCode");
            error.Domain.Should().BeNull();
            error.Description.Should().BeNull();
        }

        [Fact]
        public void ToString_ShouldReturnCorrectString()
        {
            // Act
            var error = new Error("ErrorCode", "Domain", "Description");

            // Assert
            error.ToString().Should().Be("Code: ErrorCode, Domain: Domain, Description: Description");
        }

        [Fact]
        public void ToString_WithNullDomain_ShouldReturnCorrectString()
        {
            // Act
            var error = new Error("ErrorCode", null, "Description");

            // Assert
            error.ToString().Should().Be("Code: ErrorCode, Description: Description");
        }

        [Fact]
        public void ToString_WithNullDescription_ShouldReturnCorrectString()
        {
            // Act
            var error = new Error("ErrorCode", "Domain", null);

            // Assert
            error.ToString().Should().Be("Code: ErrorCode, Domain: Domain");
        }

        [Fact]
        public void ToString_WithNullDomainAndDescription_ShouldReturnCorrectString()
        {
            // Act
            var error = new Error("ErrorCode");

            // Assert
            error.ToString().Should().Be("Code: ErrorCode");
        }
    }
}
