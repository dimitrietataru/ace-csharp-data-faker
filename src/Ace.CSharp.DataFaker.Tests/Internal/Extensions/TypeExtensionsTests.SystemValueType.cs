using Ace.CSharp.DataFaker.Internal.Extensions;

namespace Ace.CSharp.DataFaker.Tests.Internal.Extensions;

#pragma warning disable CA1812 // Avoid uninstantiated internal classes

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

    private class SystemValueTypeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { typeof(bool), "Boolean" };
            yield return new object[] { typeof(byte), "Byte" };
            yield return new object[] { typeof(char), "Char" };
            yield return new object[] { typeof(decimal), "Decimal" };
            yield return new object[] { typeof(double), "Double" };
            yield return new object[] { typeof(short), "Short" };
            yield return new object[] { typeof(int), "Int" };
            yield return new object[] { typeof(long), "Long" };
            yield return new object[] { typeof(nint), "IntPtr" };
            yield return new object[] { typeof(nuint), "UIntPtr" };
            yield return new object[] { typeof(sbyte), "SByte" };
            yield return new object[] { typeof(float), "Float" };
            yield return new object[] { typeof(ushort), "UShort" };
            yield return new object[] { typeof(uint), "UInt" };
            yield return new object[] { typeof(ulong), "ULong" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
