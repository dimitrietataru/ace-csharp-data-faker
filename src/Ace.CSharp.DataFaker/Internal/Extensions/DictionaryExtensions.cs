namespace Ace.CSharp.DataFaker.Internal.Extensions;

internal static class DictionaryExtensions
{
    public static TValue GetOrAdd<TKey, TValue>(
        this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> addFunc)
    {
        if (!dictionary.TryGetValue(key, out var value))
        {
            value = addFunc();
            dictionary.Add(key, value);
        }

        return value;
    }
}
