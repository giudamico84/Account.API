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
            var error = new Error("ErrorCode", "Description");

            // Assert
            error.Code.Should().Be("ErrorCode");
            error.Description.Should().Be("Description");
        }

        [Fact]
        public void Constructor_WithNullDomainAndDescription_ShouldInitializeCorrectly()
        {
            // Act
            var error = new Error("ErrorCode");

            // Assert
            error.Code.Should().Be("ErrorCode");
            error.Description.Should().BeNull();
        }

        [Fact]
        public void ToString_ShouldReturnCorrectString()
        {
            // Act
            var error = new Error("ErrorCode", "Description");

            // Assert
            error.ToString().Should().Be("Code: ErrorCode, Description: Description");
        }
        
        [Fact]
        public void ToString_WithNullDescription_ShouldReturnCorrectString()
        {
            // Act
            var error = new Error("ErrorCode", null);

            // Assert
            error.ToString().Should().Be("Code: ErrorCode");
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
