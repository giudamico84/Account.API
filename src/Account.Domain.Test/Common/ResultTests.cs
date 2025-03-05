using Account.Domain.Common;
using FluentAssertions;

namespace Account.Domain.Test.Common
{
    public class ResultTests
    {
        [Fact]
        public void Success_ShouldReturnIsSuccessTrue()
        {
            // Act
            var result = Result.Success;

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Error.Should().BeNull();
        }

        [Fact]
        public void Fail_WithError_ShouldReturnIsSuccessFalse()
        {
            // Arrange
            var error = new Error("ErrorCode", "Description");

            // Act
            var result = Result.Fail(error);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNull();
            result.Error!.Value.Code.Should().Be("ErrorCode");
            result.Error.Value.Description.Should().Be("Description");
        }

        [Fact]
        public void Fail_WithStringParameters_ShouldReturnIsSuccessFalseAndErrorDetails()
        {
            // Act
            var result = Result.Fail("ErrorCode", "Description");

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNull();
            result.Error!.Value.Code.Should().Be("ErrorCode");
            result.Error.Value.Description.Should().Be("Description");
        }

        [Fact]
        public void ImplicitConversionFromError_ShouldReturnFailResult()
        {
            // Arrange
            var error = new Error("ErrorCode", "Description");

            // Act
            Result result = error;

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNull();
            result.Error!.Value.Code.Should().Be("ErrorCode");
            result.Error.Value.Description.Should().Be("Description");
        }
    }
}
