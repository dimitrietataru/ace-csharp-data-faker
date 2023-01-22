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

    private class SystemStructTypeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { typeof(DateTime), "DateTime" };
            yield return new object[] { typeof(DateOnly), "DateOnly" };
            yield return new object[] { typeof(Guid), "Guid" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
