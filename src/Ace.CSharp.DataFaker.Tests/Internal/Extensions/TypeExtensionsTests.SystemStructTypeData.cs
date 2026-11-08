using Ace.CSharp.DataFaker.Internal.Extensions;

namespace Ace.CSharp.DataFaker.Tests.Internal.Extensions;

public sealed partial class TypeExtensionsTests
{
    [Theory]
    [ClassData(typeof(SystemStructTypeData))]
    internal void GivenGetFakerNameWhenTypeIsSystemStructThenReturnsName(Type type, string expected)
    {
        // Arrange

        // Act
        string actual = type.GetFakerPropertyName();

        // Assert
        actual.Should().NotBeNullOrEmpty();
        actual.Should().Be(expected);
    }

    private sealed class SystemStructTypeData : IEnumerable<TheoryDataRow<Type, string>>
    {
        public IEnumerator<TheoryDataRow<Type, string>> GetEnumerator()
        {
            yield return new(typeof(DateTime), "DateTime");
            yield return new(typeof(DateOnly), "DateOnly");
            yield return new(typeof(Guid), "Guid");
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
