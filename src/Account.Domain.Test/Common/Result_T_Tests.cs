using Account.Domain.Common;
using FluentAssertions;

namespace Account.Domain.Test.Common
{
    public class Result_T_Tests
    {
        [Fact]
        public void Success_ShouldReturnIsSuccessTrueWithValue()
        {
            // Act
            var result = Result<int>.Success(42);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(42);
            result.Error.Should().BeNull();
        }

        [Fact]
        public void Fail_WithError_ShouldReturnIsSuccessFalseWithError()
        {
            // Arrange
            var error = new Error("ErrorCode", "Domain", "Description");

            // Act
            var result = Result<int>.Fail(error);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Value.Should().Be(default(int)); // default(int) is 0
            result.Error.Should().NotBeNull();
            result.Error!.Value.Code.Should().Be("ErrorCode");
            result.Error.Value.Domain.Should().Be("Domain");
            result.Error.Value.Description.Should().Be("Description");
        }

        [Fact]
        public void ImplicitConversion_FromValue_ShouldReturnSuccessResult()
        {
            // Act
            Result<int> result = 42;

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(42);
            result.Error.Should().BeNull();
        }

        [Fact]
        public void ImplicitConversion_FromResultToValue_ShouldReturnValue()
        {
            // Act
            var result = Result<int>.Success(42);
            int value = result;

            // Assert
            value.Should().Be(42);
        }

        [Fact]
        public void ImplicitConversion_FromFailedResultToValue_ShouldThrowInvalidCastException()
        {
            // Arrange
            var error = new Error("ErrorCode", "Domain", "Description");
            var result = Result<int>.Fail(error);

            // Act & Assert
            Action act = () => { int value = result; };
            act.Should().Throw<InvalidCastException>().WithMessage("The result was not successful");
        }

        [Fact]
        public void ImplicitConversion_FromError_ShouldReturnFailResult()
        {
            // Arrange
            var error = new Error("ErrorCode", "Domain", "Description");

            // Act
            Result<int> result = error;

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNull();
            result.Error!.Value.Code.Should().Be("ErrorCode");
            result.Error.Value.Domain.Should().Be("Domain");
            result.Error.Value.Description.Should().Be("Description");
        }
    }
}
