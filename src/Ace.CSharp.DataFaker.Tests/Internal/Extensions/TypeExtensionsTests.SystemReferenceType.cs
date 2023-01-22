using Ace.CSharp.DataFaker.Internal.Extensions;

namespace Ace.CSharp.DataFaker.Tests.Internal.Extensions;

public sealed partial class TypeExtensionsTests
{
    [Theory]
    [ClassData(typeof(SystemReferenceTypeData))]
    internal void GivenGetFakerNameWhenTypeIsSystemReferenceThenReturnsName(Type type, string expected)
    {
        // Arrange

        // Act
        string actual = type.GetFakerPropertyName();

        // Assert
        actual.Should().NotBeNullOrEmpty();
        actual.Should().Be(expected);
    }

    private class SystemReferenceTypeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { typeof(object), "Object" };
            yield return new object[] { typeof(string), "String" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
