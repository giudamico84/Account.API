using Account.Domain.Common;
using FluentAssertions;

namespace Account.Domain.Test.Common
{
    public class ErrorTests
    {
        [Fact]
        public void None_ShouldHaveEmptyCodeAndDescription()
        {
            var error = Error.None;

            error.Code.Should().BeEmpty();
            error.Description.Should().BeEmpty();
            error.Type.Should().Be(ErrorType.Failure);
        }

        [Fact]
        public void NullValue_ShouldHaveCorrectProperties()
        {
            var error = Error.NullValue;

            error.Code.Should().Be("General.Null");
            error.Description.Should().Be("Null value was provided");
            error.Type.Should().Be(ErrorType.Failure);
        }

        [Fact]
        public void Failure_ShouldCreateErrorWithFailureType()
        {
            var error = Error.Failure("Test.Code", "Test failure");

            error.Code.Should().Be("Test.Code");
            error.Description.Should().Be("Test failure");
            error.Type.Should().Be(ErrorType.Failure);
        }

        [Fact]
        public void NotFound_ShouldCreateErrorWithNotFoundType()
        {
            var error = Error.NotFound("Test.Code", "Not found");

            error.Code.Should().Be("Test.Code");
            error.Description.Should().Be("Not found");
            error.Type.Should().Be(ErrorType.NotFound);
        }

        [Fact]
        public void Problem_ShouldCreateErrorWithProblemType()
        {
            var error = Error.Problem("Test.Code", "A problem occurred");

            error.Code.Should().Be("Test.Code");
            error.Description.Should().Be("A problem occurred");
            error.Type.Should().Be(ErrorType.Problem);
        }

        [Fact]
        public void Conflict_ShouldCreateErrorWithConflictType()
        {
            var error = Error.Conflict("Test.Code", "A conflict occurred");

            error.Code.Should().Be("Test.Code");
            error.Description.Should().Be("A conflict occurred");
            error.Type.Should().Be(ErrorType.Conflict);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat()
        {
            var error = new Error("Test.Code", "Test description", ErrorType.Failure);

            string expected = "Code: Test.Code, Description: Test description, ErrorType: Failure";
            error.ToString().Should().Be(expected);
        }
    }
}
