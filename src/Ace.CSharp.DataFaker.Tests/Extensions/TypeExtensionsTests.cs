using Ace.CSharp.DataFaker.Extensions;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Ace.CSharp.DataFaker.Tests.Extensions;
public class TypeExtensionsTests
{
    [Theory]
    [ClassData(typeof(SystemValueTypeData))]
    internal void GivenGetFakerNameWhenTypeIsSystemValueThenReturnsName(Type type, string expected)
    {
        // Arrange

        // Act
        string actual = type.GetFakerExhaustiveName();

        // Assert
        actual.Should().NotBeNullOrEmpty();
        actual.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(SystemReferenceTypeData))]
    internal void GivenGetFakerNameWhenTypeIsSystemReferenceThenReturnsName(Type type, string expected)
    {
        // Arrange

        // Act
        string actual = type.GetFakerExhaustiveName();

        // Assert
        actual.Should().NotBeNullOrEmpty();
        actual.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(SystemStructTypeData))]
    internal void GivenGetFakerNameWhenTypeIsSystemStructThenReturnsName(Type type, string expected)
    {
        // Arrange

        // Act
        string actual = type.GetFakerExhaustiveName();

        // Assert
        actual.Should().NotBeNullOrEmpty();
        actual.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(GenericTypeData))]
    internal void GivenGetFakerNameWhenTypeIsGenericThenReturnsName(Type type, string expected)
    {
        // Arrange

        // Act
        string actual = type.GetFakerExhaustiveName();

        // Assert
        actual.Should().NotBeNullOrEmpty();
        actual.Should().Be(expected);
    }

    private class SystemValueTypeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { typeof(bool), "Boolean" };
            yield return new object[] { typeof(char), "Char"  };
            yield return new object[] { typeof(decimal), "Decimal"  };
            yield return new object[] { typeof(double), "Double" };
            yield return new object[] { typeof(float), "Single" };
            yield return new object[] { typeof(int), "Int" };
            yield return new object[] { typeof(uint), "UInt" };
            yield return new object[] { typeof(nint), "IntPtr" };
            yield return new object[] { typeof(nuint), "UIntPtr" };
            yield return new object[] { typeof(long), "Long" };
            yield return new object[] { typeof(ulong), "ULong" };
            yield return new object[] { typeof(short), "Short" };
            yield return new object[] { typeof(ushort), "UShort" };
            yield return new object[] { typeof(byte), "Byte" };
            yield return new object[] { typeof(sbyte), "SByte" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
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

    private class GenericTypeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                typeof(IList<string>),
                "IListOfString"
            };

            yield return new object[]
            {
                typeof(ICollection<string>),
                "ICollectionOfString"
            };

            yield return new object[]
            {
                typeof(IEnumerable<string>),
                "IEnumerableOfString"
            };

            yield return new object[]
            {
                typeof(IList<IList<string>>),
                "IListOfIListOfString"
            };

            yield return new object[]
            {
                typeof(ICollection<ICollection<string>>),
                "ICollectionOfICollectionOfString"
            };

            yield return new object[]
            {
                typeof(IEnumerable<IEnumerable<string>>),
                "IEnumerableOfIEnumerableOfString"
            };

            yield return new object[]
            {
                typeof(IDictionary<string, int>),
                "IDictionaryOfStringAndInt"
            };

            yield return new object[]
            {
                typeof(IDictionary<string, IList<string>>),
                "IDictionaryOfStringAndIListOfString"
            };

            yield return new object[]
            {
                typeof(IDictionary<string, KeyValuePair<int, char>>),
                "IDictionaryOfStringAndKeyValuePairOfIntAndChar"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
