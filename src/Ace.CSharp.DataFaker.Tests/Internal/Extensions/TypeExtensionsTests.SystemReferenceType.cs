using Ace.CSharp.DataFaker.Internal.Extensions;

namespace Ace.CSharp.DataFaker.Tests.Internal.Extensions;

#pragma warning disable CA1812 // Avoid uninstantiated internal classes

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

    private sealed class SystemReferenceTypeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { typeof(object), "Object" };
            yield return new object[] { typeof(string), "String" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
