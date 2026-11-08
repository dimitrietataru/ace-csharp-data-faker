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

    private sealed class SystemReferenceTypeData : IEnumerable<TheoryDataRow<Type, string>>
    {
        public IEnumerator<TheoryDataRow<Type, string>> GetEnumerator()
        {
            yield return new(typeof(object), "Object");
            yield return new(typeof(string), "String");
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
