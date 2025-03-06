using Account.Domain.Common;
using FluentAssertions;

namespace Account.Domain.Test.Common
{
    public class Result_T_Tests
    {
        [Fact]
        public void Success_ShouldReturnTrueForIsSuccessAndCorrectValue()
        {
            // Arrange
            var value = "Test Value";
            var result = Result<string>.Success(value);

            // Act & Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(value);
            result.Error.Should().BeNull();
        }

        [Fact]
        public void Fail_WithError_ShouldReturnFalseForIsSuccessAndCorrectError()
        {
            // Arrange
            var error = new Error("ErrorCode", "Some error description", ErrorType.Validation);
            var result = Result<string>.Fail(error);

            // Act & Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(error);
            result.Value.Should().BeNull();
        }

        [Fact]
        public void ImplicitOperator_ShouldConvertValueToResult()
        {
            // Arrange
            var value = "Test Value";

            // Act
            Result<string> result = value;

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(value);
            result.Error.Should().BeNull();
        }

        [Fact]
        public void ImplicitOperator_ShouldThrowExceptionWhenResultIsFail()
        {
            // Arrange
            var error = new Error("ErrorCode", "Some error description", ErrorType.Validation);
            var result = Result<string>.Fail(error);

            // Act & Assert
            Assert.Throws<InvalidCastException>(() => { string value = result; });
        }

        [Fact]
        public void ImplicitOperator_ShouldConvertResultToValueWhenSuccessful()
        {
            // Arrange
            var value = "Test Value";
            var result = Result<string>.Success(value);

            // Act
            var actualValue = result.Value;

            // Assert
            actualValue.Should().Be(value);
        }
    }
}
