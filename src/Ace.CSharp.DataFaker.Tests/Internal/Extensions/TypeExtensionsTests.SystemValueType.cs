using Ace.CSharp.DataFaker.Internal.Extensions;

namespace Ace.CSharp.DataFaker.Tests.Internal.Extensions;

public sealed partial class TypeExtensionsTests
{
    [Theory]
    [ClassData(typeof(SystemValueTypeData))]
    internal void GivenGetFakerNameWhenTypeIsSystemValueThenReturnsName(Type type, string expected)
    {
        // Arrange

        // Act
        string actual = type.GetFakerPropertyName();

        // Assert
        actual.Should().NotBeNullOrEmpty();
        actual.Should().Be(expected);
    }

    private sealed class SystemValueTypeData : IEnumerable<TheoryDataRow<Type, string>>
    {
        public IEnumerator<TheoryDataRow<Type, string>> GetEnumerator()
        {
            yield return new(typeof(bool), "Boolean");
            yield return new(typeof(byte), "Byte");
            yield return new(typeof(char), "Char");
            yield return new(typeof(decimal), "Decimal");
            yield return new(typeof(double), "Double");
            yield return new(typeof(short), "Short");
            yield return new(typeof(int), "Int");
            yield return new(typeof(long), "Long");
            yield return new(typeof(nint), "IntPtr");
            yield return new(typeof(nuint), "UIntPtr");
            yield return new(typeof(sbyte), "SByte");
            yield return new(typeof(float), "Float");
            yield return new(typeof(ushort), "UShort");
            yield return new(typeof(uint), "UInt");
            yield return new(typeof(ulong), "ULong");
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
