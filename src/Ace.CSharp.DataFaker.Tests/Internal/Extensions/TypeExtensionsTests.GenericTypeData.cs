using Ace.CSharp.DataFaker.Internal.Extensions;

namespace Ace.CSharp.DataFaker.Tests.Internal.Extensions;

public sealed partial class TypeExtensionsTests
{
    [Theory]
    [ClassData(typeof(GenericTypeData))]
    internal void GivenGetFakerNameWhenTypeIsGenericThenReturnsName(Type type, string expected)
    {
        // Arrange

        // Act
        string actual = type.GetFakerPropertyName();

        // Assert
        actual.Should().NotBeNullOrEmpty();
        actual.Should().Be(expected);
    }

    private sealed class GenericTypeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                typeof(IEnumerable<string>),
                "IEnumerableOfString"
            };

            yield return new object[]
            {
                typeof(ICollection<string>),
                "ICollectionOfString"
            };

            yield return new object[]
            {
                typeof(IList<string>),
                "IListOfString"
            };

            yield return new object[]
            {
                typeof(IEnumerable<IEnumerable<string>>),
                "IEnumerableOfIEnumerableOfString"
            };

            yield return new object[]
            {
                typeof(ICollection<ICollection<string>>),
                "ICollectionOfICollectionOfString"
            };

            yield return new object[]
            {
                typeof(IList<IList<string>>),
                "IListOfIListOfString"
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
