using Account.Domain.Common;
using FluentAssertions;

namespace Account.Domain.Test.Common
{
    public class ResultTests
    {
        [Fact]
        public void Success_ShouldReturnTrueForIsSuccessAndNoError()
        {
            // Arrange
            var result = Result.Success;

            // Act & Assert
            result.IsSuccess.Should().BeTrue();
            result.Error.Should().BeNull();
        }

        [Fact]
        public void Fail_WithError_ShouldReturnFalseForIsSuccessAndError()
        {
            // Arrange
            var error = new Error("ErrorCode", "Some error description", ErrorType.Validation);
            var result = Result.Fail(error);

            // Act & Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Fail_WithParameters_ShouldReturnFalseForIsSuccessAndCorrectError()
        {
            // Arrange
            var result = Result.Fail("ErrorCode", "Some error description", ErrorType.Validation);

            // Act & Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNull();
            result.Error?.Code.Should().Be("ErrorCode");
            result.Error?.Description.Should().Be("Some error description");
            result.Error?.Type.Should().Be(ErrorType.Validation);
        }

        [Fact]
        public void ImplicitOperator_ShouldConvertErrorToResult()
        {
            // Arrange
            var error = new Error("ErrorCode", "Some error description", ErrorType.Validation);

            // Act
            Result result = error;

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(error);
        }
    }
}
