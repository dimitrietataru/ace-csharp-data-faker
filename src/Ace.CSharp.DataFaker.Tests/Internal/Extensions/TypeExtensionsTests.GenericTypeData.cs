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

    private sealed class GenericTypeData : IEnumerable<TheoryDataRow<Type, string>>
    {
        public IEnumerator<TheoryDataRow<Type, string>> GetEnumerator()
        {
            yield return new(typeof(IEnumerable<string>), "IEnumerableOfString");
            yield return new(typeof(ICollection<string>), "ICollectionOfString");
            yield return new(typeof(IList<string>), "IListOfString");
            yield return new(typeof(IEnumerable<IEnumerable<string>>), "IEnumerableOfIEnumerableOfString");
            yield return new(typeof(ICollection<ICollection<string>>), "ICollectionOfICollectionOfString");
            yield return new(typeof(IList<IList<string>>), "IListOfIListOfString");
            yield return new(typeof(IDictionary<string, int>), "IDictionaryOfStringAndInt");
            yield return new(typeof(IDictionary<string, IList<string>>), "IDictionaryOfStringAndIListOfString");
            yield return new(typeof(IDictionary<string, KeyValuePair<int, char>>), "IDictionaryOfStringAndKeyValuePairOfIntAndChar");
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
